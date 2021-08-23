using MediatR;
using Microsoft.EntityFrameworkCore;
using NEXOSAPI.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.CustomerFeatures.Commands
{
    public class DeleteBookByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteBookByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCustomerByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBookByIdCommand request, CancellationToken cancellationToken)
            {
                var book = await _context.Books.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (book == null) return default;
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return book.Id;
            }
        }
    }
}
