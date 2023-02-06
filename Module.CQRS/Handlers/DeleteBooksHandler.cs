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
    public class DeleteBooksHandler : IRequestHandler<DeleteBooksCommand, Books>
    {
        private readonly Books _books;

        public DeleteBooksHandler(Books books)
        {
            _books = books;
        }

        public async Task<Books> Handle(DeleteBooksCommand request, CancellationToken cancellationToken)
        {
            var book = _books.RemoveBooks(request.Id);

            return book;
        }

    }
}