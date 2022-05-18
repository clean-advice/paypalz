using Devlin.PayPalz.TaxCalculationApi;
using Devlin.PayPalz.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace Devlin.PayPalz.Web.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string? PostalCode { get; set; }

        [TempData]
        public string? Salary { get; set; }

        [TempData]
        public string? TaxPayable { get; set; }

        public SelectList PostalCodes { get; set; }

        [BindProperty]
        public TaxCalculationModel TaxCalculationModel { get; set; }

        private readonly TaxCalculationApiClient _taxCalculationApiClient;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            var httpClient = httpClientFactory.CreateClient("TaxCalculationApi");
            _taxCalculationApiClient = new TaxCalculationApiClient(httpClient);
            TaxCalculationModel = new TaxCalculationModel();
            this.PostalCodes = new SelectList(GetPostalCodes(), "Value", "Text");
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            CultureInfo culture = new CultureInfo("en-ZA");
            decimal salary;
            if (!decimal.TryParse(TaxCalculationModel.Salary, out salary))
            {
                ModelState.AddModelError(nameof(TaxCalculationModel.Salary), $"{nameof(TaxCalculationModel.Salary)} is not a valid decimal value.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var calculateRequest = new CalculateRequest
            {
                PostalCode = TaxCalculationModel.PostalCode,
                Salary = salary,
            };

            try
            {
                CalculateResponse? response = await _taxCalculationApiClient.Tax_CalculateAsync(calculateRequest);
                TaxPayable = response.TaxCalculationResult.TaxPayable.ToString("C", culture);
                Salary = response.TaxCalculationResult.Salary.ToString("C", culture);
                PostalCode = response.TaxCalculationResult.PostalCode;
            }
            catch (ArgumentException argEx)
            {
                ModelState.AddModelError(nameof(TaxCalculationModel.PostalCode), argEx.Message);
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(TaxCalculationModel.PostalCode), "An error occurred, please try again. ");
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private static List<SelectListItem> GetPostalCodes() => new List<SelectListItem>
            {
                new SelectListItem {Text = "A100", Value = "A100" },
                new SelectListItem {Text = "1000", Value = "1000" },
                new SelectListItem {Text = "7000", Value = "7000" },
                new SelectListItem {Text = "7441", Value = "7441" },
            };
    }
}