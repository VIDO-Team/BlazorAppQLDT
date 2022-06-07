using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace BlazorAppQLDT.Componants
    {
        public class ConfirmBase : ComponentBase
        {
            protected bool ShowConfirmation { get; set; }
            
            public void Show()
            {
                ShowConfirmation = true;
                StateHasChanged();
            }

            [Parameter]
            public EventCallback<bool> ConfirmationChanged { get; set; }

            protected async Task OnConfirmationChange(bool value)
            {
                ShowConfirmation = false;
                await ConfirmationChanged.InvokeAsync(value);
            }
        }
    }