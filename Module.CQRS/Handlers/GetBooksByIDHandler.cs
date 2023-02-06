using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreReservation.Module.CQRS.Models;
using BookStoreReservation.Module.CQRS.Queries;
using MediatR;

namespace BookStoreReservation.Module.CQRS.Handlers
{
    public class GetBooksByIDHandler : IRequestHandler<GetBookByIDQuery, Books>
    {
        private readonly Books _books;

        public GetBooksByIDHandler(Books books)
        {
            _books = books;
        }

        public async Task<Books> Handle(GetBookByIDQuery request, CancellationToken cancellationToken)
        {
            return _books.AllBooks().Where(x => x.BookID == request.Id.ToString()).SingleOrDefault();
        }
    }
}