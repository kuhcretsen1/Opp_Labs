using System.Linq.Expressions;
using System.Text;

namespace NextLab.Builder
{
    public abstract class SqlBuilder<T>
    {
        protected StringBuilder query;

        public SqlBuilder(StringBuilder query)
        {
            this.query = query;
        }

        public abstract SqlBuilder<T> Select();
        public abstract SqlBuilder<T> Where(Expression<Func<T, bool>> condition);
        public abstract SqlBuilder<T> OrderBy(Expression<Func<T, object>> condition);
        public abstract SqlBuilder<T> Take(int count);
        public abstract string Build();
        protected string GetOperator(ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.NotEqual:
                    return "!=";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                default:
                    throw new ArgumentException("Unsupported operator");
            }
        }

    }
}
