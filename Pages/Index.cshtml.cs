using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MacApp.Pages;

public class IndexModel : PageModel
{
    // Senarai untuk menyimpan aset secara sementara dalam memori server
    public static List<Aset> SenaraiAset { get; set; } = new List<Aset>()
    {
        new Aset { NoSiri = "KPM/ICT/2026/001", Nama = "Ahmads MacBook Air", Kategori = "Komputer Riba / PC", Status = "Baik" }
    };

    // Properties yang diikat (Bind) dengan input borang HTML
    [BindProperty]
    public string NamaAset { get; set; } = string.Empty;
    [BindProperty]
    public string NoSiriAset { get; set; } = string.Empty;
    [BindProperty]
    public string KategoriAset { get; set; } = string.Empty;

    public void OnGet()
    {
        // Berjalan apabila halaman mula-mula dibuka
    }

    public IActionResult OnPost()
    {
        // Berjalan apabila butang "Submit" borang ditekan
        if (!string.IsNullOrEmpty(NamaAset) && !string.IsNullOrEmpty(NoSiriAset))
        {
            // Tambah data baru dari borang ke dalam senarai
            SenaraiAset.Add(new Aset 
            { 
                Nama = NamaAset, 
                NoSiri = NoSiriAset, 
                Kategori = KategoriAset, 
                Status = "Baik" 
            });
        }

        // Segarkan semula halaman untuk paparan data baru
        return RedirectToPage();
    }
}

// Model kelas untuk mendefinisikan struktur data Aset
public class Aset
{
    public string NoSiri { get; set; } = string.Empty;
    public string Nama { get; set; } = string.Empty;
    public string Kategori { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
