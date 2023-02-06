using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreReservation.Module.CQRS.Models;
using MediatR;

namespace BookStoreReservation.Module.CQRS.Commands
{
    public class CreateBooksCommand : IRequest<Books>
    {
        public Books Books { get; }

        public CreateBooksCommand(Books books)
        {
            Books = books;
        }
    }
}