using BookManagementCQRSMediatR.Models;
using MediatR;

namespace BookManagementCQRSMediatR.Features.Books.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
    {
    }
}
