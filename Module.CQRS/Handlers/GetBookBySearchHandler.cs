using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreReservation.Module.CQRS.Queries;
using BookStoreReservation.Module.CQRS.Models;
using MediatR;

namespace BookStoreReservation.Module.CQRS.Handlers
{
    public class GetBookBySearchHandler : IRequestHandler<GetBookBySearchQuery, List<Books>>
    {
        private readonly Books _books;

        public GetBookBySearchHandler(Books books)
        {
            _books = books;
        }
        public async Task<List<Books>> Handle(GetBookBySearchQuery request, CancellationToken cancellationToken)
        {
            return _books.AllBooks().Where(x => x.BookName.Contains(request.BookName.ToString())).ToList();
        }

    }
}