using MediatR;
using NEXOSAPI.Domain.Entities;
using NEXOSAPI.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.CustomerFeatures.Queries
{
    public class GetAuthorByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Book>
        {
            private readonly IApplicationDbContext _context;
            public GetCustomerByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Book> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
            {
                var book = _context.Books.Where(a => a.Id == request.Id).FirstOrDefault();
                if (book == null) return null;
                return book;
            }
        }
    }
}
