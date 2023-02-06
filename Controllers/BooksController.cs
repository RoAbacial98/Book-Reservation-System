using Microsoft.AspNetCore.Mvc;
using BookStoreReservation.Module.CQRS.Models;
using MediatR;
using BookStoreReservation.Module.CQRS.Queries;
using BookStoreReservation.Module.CQRS.Commands;

namespace BookStoreReservation.Controllers
{
    [Route("[controller]")]
    public class BooksController : Controller
    {

        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/Books")]
        public async Task<IActionResult> Index(string Search)
        {
            //Loads All The Books
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);

            if (Search != null)
            {
                //Seach For the Book
                var querySearch = new GetBookBySearchQuery(Search);
                var resultSearch = await _mediator.Send(querySearch);
                return View(resultSearch);
            }

            return View(result);
        }


        [HttpGet("/BookDetails")]
        public async Task<IActionResult> BookDetails(string BookID)
        {
            //Get Book By Id
            var query = new GetBookByIDQuery(BookID);
            var result = await _mediator.Send(query);
            return View(result);
        }

        [HttpPost("/BookingNumber")]
        public IActionResult BookingNumber(Books book)
        {
            //If Null direct automatically to Index.
            if (book.BookReserve == false)
            {
                return RedirectToAction("Index");
            }
            book.BookReserveNumber = RandomBookingNumber();

            //Delete The Record form List Since I did not use DB
            var queryDelete = new DeleteBooksCommand(book.BookID);
            _mediator.Send(queryDelete);

            //Create The Record form List Since I did not use DB
            var queryCreate = new CreateBooksCommand(book);
            _mediator.Send(queryCreate);

            return View(book);
        }

        public string RandomBookingNumber()
        {
            //Booking Number
            var random = new Random();
            return random.Next().ToString();
        }
    }
}