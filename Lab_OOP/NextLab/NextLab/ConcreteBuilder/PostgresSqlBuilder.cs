using NextLab.Builder;
using System.Linq.Expressions;
using System.Text;

namespace 
    NextLab.ConcreteBuilder
{
    internal class PostgresSqlBuilder<T> : SqlBuilder<T>
    {
        public PostgresSqlBuilder(StringBuilder queryBuilder) : base(queryBuilder)
        {
        }
        public override SqlBuilder<T> Select()
        {
            query.Append($"SELECT * FROM \"{typeof(T).Name}\" ");
            return this;
        }

        public override SqlBuilder<T> Where(Expression<Func<T, bool>> condition)
        {
            var binaryExpression = condition.Body as BinaryExpression;
            if (binaryExpression == null)
            {
                throw new ArgumentException("Expression must be a binary expression");
            }

            var propertyName = ((MemberExpression)binaryExpression.Left).Member.Name;
            var value = binaryExpression.Right;
            var conditionOperator = GetOperator(binaryExpression.NodeType);

            query.Append($"WHERE {propertyName} {conditionOperator} {value} ");
            return this;
        }
        public override SqlBuilder<T> OrderBy(Expression<Func<T, object>> condition)
        {
            UnaryExpression unaryExpression = (UnaryExpression)condition.Body;
            MemberExpression memberExpression = (MemberExpression)unaryExpression.Operand;
            string propertyName = memberExpression.Member.Name;
            query.Append($"ORDER BY {propertyName} ");

            return this;
        }

        public override SqlBuilder<T> Take(int count)
        {
            query.Append($"LIMIT {count}");
            return this;
        }

        public override string Build()
        {
            return query.ToString();
        }
    }
}