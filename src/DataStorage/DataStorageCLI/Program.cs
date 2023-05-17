using System;
using DataStorageLibrary.ConnectionProvider;
using DataStorageLibrary.ConnectionProvider.Impl;
using DataStorageLibrary.Storages;
using DataStorageLibrary.Storages.Impl;
using DataStorageLibrary.Storages.Factory.Impl;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using DataLibrary.Formatter;
using DataLibrary.Formatters;
using DataStorageLibrary.Data;
using DataStorageLibrary.Formatters;

namespace DataStorageCLI
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }
        public static BookStorage BookStorage { get; }

        static void Main(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();

            IConnectionProvider connectionProvider = new PgConnectionProvider(configuration.GetConnectionString("con"));
            IBookStorage bookStorage = new BookStorageFactory(connectionProvider).Create();
            IFormatter<Book> bookFormatter = new BookMetadataFormatter();
            IFormatter<ContentIndex> contentIndexFormatter = new ContentIndexFormatter();

            var app = new CommandLineApplication();
            app.Name = "DataStorage";
            app.HelpOption("-?|-h|--help");

            app.Command("Books", (command) =>
            {
                command.Description = "Manages the storage of books.";
                command.HelpOption("-?|-h|--help");

                command.Command("get_ids", (action) =>
                {
                    action.Description = "Lists id's of all stored books.";
                    action.HelpOption("-?|-h|--help");
                    action.OnExecute(() =>
                    {
                        Console.WriteLine(String.Join(", ", bookStorage.GetAllIds()));
                        return 0;
                    });
                });

                command.Command("get_item", (action) =>
                {
                    action.Description = "Displays data of selected book.";
                    action.HelpOption("-?|-h|--help");
                    CommandArgument idArg = action.Argument("{id}", "Id of book");
                    action.OnExecute(() =>
                    {
                        int id;
                        if (int.TryParse(idArg.Value, out id))
                        {
                            var item = bookStorage.GetById(id);
                            if(item==null)
                            {
                                Console.WriteLine(String.Format("Object with id {0} has not been found.", id));
                                return -1;
                            }
                            Console.WriteLine(bookFormatter.Format(item));
                        }
                        else
                        {
                            Console.WriteLine("It needs to be provided valid id number.");
                            action.ShowHint();
                        }
                        return 0;
                    });

                });

                command.Command("get_content_index", (action) =>
                {
                    action.Description = "Displays table of content of selected book.";
                    action.HelpOption("-?|-h|--help");
                    CommandArgument idArg = action.Argument("{id}", "Id of book");
                    action.OnExecute(() =>
                    {
                        int id;
                        if (int.TryParse(idArg.Value, out id))
                        {
                            var tableOfContentList = bookStorage.GetTableOfContent(id);
                            foreach (var contentIndex in tableOfContentList)
                            {
                                Console.WriteLine(contentIndexFormatter.Format(contentIndex));
                            }
                        }
                        return 0;
                    });

                });
            });
            app.Execute(args);
        }
    }
}
