using System;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Books;

public class EditModalModel : BookStorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateBookDto Book { get; set; }

    private readonly IBookAppService _bookAppService;

    public EditModalModel(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    public async Task OnGetAsync()
    {
        /* _bookAppService.GetAsync(Id) returns BookDto type data,
         * BookDto doesn't have validation in it, 
         * before saving this data in database we need to perform serverside validation 
         * thus used automapper to copy data from BookDto to CreateUpdateBookDto (which has validation in it)
         */
        var bookDto = await _bookAppService.GetAsync(Id); 
        Book = ObjectMapper.Map<BookDto, CreateUpdateBookDto>(bookDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _bookAppService.UpdateAsync(Id, Book);
        return NoContent();
    }
}
