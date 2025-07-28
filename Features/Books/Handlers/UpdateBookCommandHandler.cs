using BookManagementCQRSMediatR.Data;
using BookManagementCQRSMediatR.Features.Books.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagementCQRSMediatR.Features.Books.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookTitleCommand, bool>
    {
        private readonly AppDbContext _context;
        public UpdateBookCommandHandler(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> Handle(UpdateBookTitleCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);
            
            if (book == null) return false;

            book.Title = request.NewTitle;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
