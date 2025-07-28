using BookManagementCQRSMediatR.Data;
using BookManagementCQRSMediatR.Features.Books.Queries;
using BookManagementCQRSMediatR.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagementCQRSMediatR.Features.Books.Handlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly AppDbContext _context;
        public GetAllBooksQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.ToListAsync(cancellationToken);
        }
    }
}
