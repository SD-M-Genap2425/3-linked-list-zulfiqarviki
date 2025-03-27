using System;
using System.ComponentModel;
using System.Text;

namespace LinkedList.Perpustakaan
{
    public class Buku
    {
        public string Judul {get;set;}
        public string Penulis {get;set;}
        public int Tahun {get;set;}

        public Buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Data {get;set;}
        public Buku Buku {get;set;}
        public BukuNode Next {get;set;}

        public BukuNode(Buku buku)
        {
            Data = buku;
            Buku = buku;
            Next = null;
        }
    }

    public class KoleksiPerpustakaan
    {
        private BukuNode head;

        public void TambahBuku(Buku buku)
        {
            BukuNode newNode = new BukuNode(buku);
            if(head == null)
            {
                head = newNode;
            }
            else
            {
                BukuNode current = head;
                while(current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public bool HapusBuku(string judul)
        {
            if(head == null) return false;

            if(head.Buku.Judul == judul)
            {
                head = head.Next;
                return true;
            }

            BukuNode current = head;
            while(current.Next != null && current.Next.Buku.Judul != judul)
            {
                current = current.Next;
            }

            if(current.Next == null) return false;

            current.Next = current.Next.Next;
            return true;
        }

        public Buku[] CariBuku(string kataKunci)
        {
            List<Buku> hasilPencarian = new List<Buku>();
            BukuNode current = head;
            while(current != null)
            {
                if(current.Buku.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
                {
                    hasilPencarian.Add(current.Buku);
                }
                current = current.Next;
            }
            return hasilPencarian.ToArray();
        }

        public string TampilkanKoleksi()
        {
            if(head == null) return "";

            StringBuilder koleksi = new StringBuilder();
            BukuNode current = head;
            while(current != null)
            {
                koleksi.AppendLine($"\"{current.Buku.Judul}\"; {current.Buku.Penulis}; {current.Buku.Tahun}");
                current = current.Next;
            }

            return koleksi.ToString();
            
        }
    }
}