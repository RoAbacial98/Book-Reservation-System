using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreReservation.Module.CQRS.Models;
using MediatR;

namespace BookStoreReservation.Module.CQRS.Queries
{
    public class GetBookBySearchQuery : IRequest<List<Books>>
    {
        public string BookName { get; }

        public GetBookBySearchQuery(string bookName)
        {
            BookName = bookName;
        }
    }
}