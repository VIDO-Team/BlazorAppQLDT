using Microsoft.AspNetCore.Components;

namespace BlazorAppQLDT.Client.Pages.CD15.Components
{
    public partial class Pagination
    {
        [Parameter]
        public MetaData metaData { get; set; }
        [Parameter]
        public int Spread { get; set; }
        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }
        private List<PagingLink> _links;

        protected virtual void OnParametersSet()
        {
            CreatePaginationLinks();
        }
        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>();
            _links.Add(new PagingLink(metaData.CurrentPage - 1, metaData.HasPrevious, "Previous"));
            for (int i = 1; i <= metaData.TotalPages; i++)
            {
                if(i >= metaData.CurrentPage - Spread && i <= metaData.CurrentPage + Spread)
                {
                    _links.Add(new PagingLink(i, true, i.ToString()) { Active = metaData.CurrentPage == i });
                }
            }
            _links.Add(new PagingLink(metaData.CurrentPage + 1, metaData.HasNext, "Next"));
        }
        private async Task OnSelectedPage(PagingLink link)
        {
            if (link.Page == metaData.CurrentPage || !link.Enabled)
                return;
            metaData.CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}
