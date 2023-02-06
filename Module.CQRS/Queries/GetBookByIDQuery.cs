using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreReservation.Module.CQRS.Models;
using MediatR;

namespace BookStoreReservation.Module.CQRS.Queries
{
    public class GetBookByIDQuery : IRequest<Books>
    {
        public string Id { get; }

        public GetBookByIDQuery(string id)
        {
            Id = id;
        }
    }
}