using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcServiceDemo
{
    public class GreeterService  : BookService.BookServiceBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        //public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        //{
        //    return Task.FromResult(new HelloReply
        //    {
        //        Message = "Hello " + request.Name
        //    });
        //}

        public override Task<Book> GetBook(GetBookRequest request, ServerCallContext context)
        {
            return Task.FromResult(new Book
            {
                Author = "J.K Rowlings",
                Title = "Harry Potter",
                Isbn = 1
            });
        }

        public override Task QueryBooks(QueryBooksRequest request, IServerStreamWriter<Book> responseStream, ServerCallContext context)
        {
            return base.QueryBooks(request, responseStream, context);
        }
    }
}
