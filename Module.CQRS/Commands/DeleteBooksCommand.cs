using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreReservation.Module.CQRS.Models;
using MediatR;

namespace BookStoreReservation.Module.CQRS.Commands
{
    public class DeleteBooksCommand : IRequest<Books>
    {
        public string Id { get; }

        public DeleteBooksCommand(string id)
        {
            Id = id;
        }
    }
}