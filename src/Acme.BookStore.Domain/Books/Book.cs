using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books;

public class Book : AuditedAggregateRoot<Guid>
// AuditedAggregateRoot<TPrimaryKey> class is a generic class where TPrimaryKey is the type of the primary key for your entity.
// AuditedAggregateRoot is part of DDD principles, peek the properties in it.
// it contains auditing properties: involves recording who made changes, when changes were made, and what changes were made to the domain entities. 
{
    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }

}
