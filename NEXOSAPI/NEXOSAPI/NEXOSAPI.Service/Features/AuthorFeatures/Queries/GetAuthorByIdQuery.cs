using MediatR;
using NEXOSAPI.Domain.Entities;
using NEXOSAPI.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.AuthorFeatures.Queries
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public int Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
        {
            private readonly IApplicationDbContext _context;
            public GetCustomerByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
            {
                var author = _context.Authors.Where(a => a.Id == request.Id).FirstOrDefault();
                if (author == null) return null;
                return author;
            }
        }
    }
}
