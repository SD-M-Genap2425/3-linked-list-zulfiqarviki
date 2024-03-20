namespace LinkedList.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList.Perpustakaan;

[TestClass]
public class PerpustakaanTests
{
    [TestMethod]
    public void Buku_AksesPropertiBuku_PropertiBukuBisaDiakses()
    {
        var buku = new Buku("Test Book", "Test Author", 2021);
       
        Assert.IsTrue(buku.Judul.Equals("Test Book"));
        Assert.IsTrue(buku.Penulis.Equals("Test Author"));
        Assert.IsTrue(buku.Tahun == 2021);
    }

    [TestMethod]
    public void BukuNode_AksesPropertiBukuNode_PropertiBukuBisaDiakses()
    {
        var buku = new Buku("Test Book", "Test Author", 2021);

        var node = new BukuNode(buku);

        Assert.IsTrue(node.Data.Judul.Equals("Test Book"));
        Assert.IsTrue(node.Data.Penulis.Equals("Test Author"));
        Assert.IsTrue(node.Data.Tahun == 2021);
    }

    [TestMethod]
    public void BukuNode_AksesPropertiNext_PropertiNextBisaDiakses()
    {
        var buku1 = new Buku("Test Book 1", "Test Author", 2021);
        var buku2 = new Buku("Test Book 2", "Test Author", 2022);

        var node = new BukuNode(buku1);
        node.Next = new BukuNode(buku2);

        Assert.IsTrue(node.Next.Data.Judul.Equals("Test Book 2"));
        Assert.IsTrue(node.Next.Data.Penulis.Equals("Test Author"));
        Assert.IsTrue(node.Next.Data.Tahun == 2022);
    }

    [TestMethod]
    public void TambahBuku_TambahkanSatuBuku_KoleksiMengandungBuku()
    {
        var perpustakaan = new KoleksiPerpustakaan();
        var buku = new Buku("Test Book", "Test Author", 2021);
        perpustakaan.TambahBuku(buku);

        string result = perpustakaan.TampilkanKoleksi();
        Assert.IsTrue(result.Contains("\"Test Book\"; Test Author; 2021"));
    }

    [TestMethod]
    public void TambahBuku_TambahkanTigaBuku_KoleksiMengandungBuku()
    {
        var perpustakaan = new KoleksiPerpustakaan();
        var buku1 = new Buku("Test Book 1", "Test Author", 2021);
        var buku2 = new Buku("Test Book 2", "Test Author", 2021);
        var buku3 = new Buku("Test Book 3", "Test Author", 2021);

        perpustakaan.TambahBuku(buku1);
        perpustakaan.TambahBuku(buku2);
        perpustakaan.TambahBuku(buku3);

        string result = perpustakaan.TampilkanKoleksi();
        Assert.IsTrue(result.Contains("\"Test Book 1\"; Test Author; 2021"));
        Assert.IsTrue(result.Contains("\"Test Book 2\"; Test Author; 2021"));
        Assert.IsTrue(result.Contains("\"Test Book 3\"; Test Author; 2021"));
    }

    [TestMethod()]
    public void CariBuku_CariBukuYangAda_BukuDitemukan()
    {
        var perpustakaan = new KoleksiPerpustakaan();
        perpustakaan.TambahBuku(new Buku("The Hobbit", "J.R.R. Tolkien", 1937));
        perpustakaan.TambahBuku(new Buku("1984", "George Orwell", 1949));

        var bukuDitemukan = perpustakaan.CariBuku("1984");
        Assert.AreEqual(1, bukuDitemukan.Length); // Memastikan satu buku ditemukan
        Assert.AreEqual("1984", bukuDitemukan[0].Judul); // Memastikan judul buku yang ditemukan sesuai
    }

    [TestMethod()]
    public void CariBuku_CariBukuYangTidakAda_BukuTidakDitemukan()
    {
        var perpustakaan = new KoleksiPerpustakaan();
        perpustakaan.TambahBuku(new Buku("The Hobbit", "J.R.R. Tolkien", 1937));
        perpustakaan.TambahBuku(new Buku("1984", "George Orwell", 1949));

        var bukuTidakDitemukan = perpustakaan.CariBuku("Non-Existing Title");
        Assert.AreEqual(0, bukuTidakDitemukan.Length); // Memastikan tidak ada buku yang ditemukan
    }


    [TestMethod]
    public void HapusBuku_HapusBukuYangAda_BukuDihapusDariKoleksi()
    {
        var perpustakaan = new KoleksiPerpustakaan();
        perpustakaan.TambahBuku(new Buku("To Be Deleted", "Author", 2020));
        bool isDeleted = perpustakaan.HapusBuku("To Be Deleted");

        Assert.IsTrue(isDeleted, "Buku seharusnya dihapus.");
        Assert.IsFalse(perpustakaan.TampilkanKoleksi().Contains("To Be Deleted"), "Buku 'To Be Deleted' seharusnya tidak ada dalam koleksi.");
    }

    [TestMethod]
    public void HapusBuku_HapusBukuYangTidakAda_PenghapusanGagal()
    {
        var perpustakaan = new KoleksiPerpustakaan();
        perpustakaan.TambahBuku(new Buku("Some Book", "Some Author", 2021));
        bool isDeleted = perpustakaan.HapusBuku("Non-Existent Book");

        Assert.IsFalse(isDeleted, "Penghapusan buku yang tidak ada seharusnya gagal.");
    }

    [TestMethod]
    public void TampilkanKoleksi_KoleksiKosong_TidakAdaOutput()
    {
        var perpustakaan = new KoleksiPerpustakaan();
        string result = perpustakaan.TampilkanKoleksi();

        Assert.AreEqual(string.Empty, result, "Tidak seharusnya ada output untuk koleksi kosong.");
    }

    [TestMethod]
    public void TampilkanKoleksi_KoleksiDenganBuku_OutputDaftarBuku()
    {
        var perpustakaan = new KoleksiPerpustakaan();
        perpustakaan.TambahBuku(new Buku("Book1", "Author1", 2001));
        perpustakaan.TambahBuku(new Buku("Book2", "Author2", 2002));

        string result = perpustakaan.TampilkanKoleksi();
        Assert.IsTrue(result.Contains("\"Book1\"; Author1; 2001"), "Koleksi seharusnya mengandung 'Book1'.");
        Assert.IsTrue(result.Contains("\"Book2\"; Author2; 2002"), "Koleksi seharusnya mengandung 'Book2'.");
    }
}

