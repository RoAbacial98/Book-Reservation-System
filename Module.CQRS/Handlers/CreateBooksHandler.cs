using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreReservation.Module.CQRS.Queries;
using MediatR;
using BookStoreReservation.Module.CQRS.Models;
using BookStoreReservation.Module.CQRS.Commands;

namespace BookStoreReservation.Module.CQRS.Handlers
{
    public class CreateBooksHandler : IRequestHandler<CreateBooksCommand, Books>
    {
        private readonly Books _books;

        public CreateBooksHandler(Books books)
        {
            _books = books;
        }

        public Task<Books> Handle(CreateBooksCommand request, CancellationToken cancellationToken)
        {
            var books = _books.AddBooks(request.Books);

            return null;
        }

    }
}