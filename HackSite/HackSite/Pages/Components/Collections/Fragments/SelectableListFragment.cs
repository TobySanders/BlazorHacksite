using Microsoft.AspNetCore.Components;

namespace HackSite.Pages.Components.Collections.Fragments
{
    public class SelectableListFragment<TItem,TKey>
    {
        public TItem Item { get; set; }
        public EventCallback<TKey> OnSelected { get; set; }
        public EventCallback<TKey> OnDeselected { get; set; }
    }
}
