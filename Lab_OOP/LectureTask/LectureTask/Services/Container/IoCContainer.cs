using LectureTask.Services.Commands;
using LectureTask.Services.ConsoleWrap;
using LectureTask.Services.Interfaces;
using LectureTask.Services.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace LectureTask.Services.Container;

public static class IoCContainer
{
    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<ICompressionStrategy, LowCompressionStrategy>()
            .AddSingleton<ICompressionStrategy, MediumCompressionStrategy>()
            .AddSingleton<ICompressionStrategy, HighCompressionStrategy>()
            .AddSingleton<ICommand, ZipFileCompressionCommand>()
            .AddSingleton<ICommand, ZipFolderCompressionCommand>()
            .AddSingleton<ICommand, ExitCommand>()
            .AddSingleton<ICommand, UnZipCommand>()
            .AddSingleton<IConsoleWrapper, ConsoleWrapper>();
    }
}