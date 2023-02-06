using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreReservation.Module.CQRS.Queries;
using MediatR;
using BookStoreReservation.Module.CQRS.Models;

namespace BookStoreReservation.Module.CQRS.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<Books>>
    {
        private readonly Books _books;

        public GetAllBooksHandler(Books books)
        {
            _books = books;
        }
        public async Task<List<Books>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return _books.AllBooks();
        }

    }
}