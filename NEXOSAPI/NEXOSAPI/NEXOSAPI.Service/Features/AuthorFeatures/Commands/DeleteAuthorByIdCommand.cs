using MediatR;
using Microsoft.EntityFrameworkCore;
using NEXOSAPI.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.CustomerFeatures.Commands
{
    public class DeleteAuthorByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteAuthorByIdCommandHandler : IRequestHandler<DeleteAuthorByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteAuthorByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteAuthorByIdCommand request, CancellationToken cancellationToken)
            {
                var author = await _context.Authors.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (author == null) return default;
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return author.Id;
            }
        }
    }
}
