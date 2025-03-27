using System;
using System.Reflection.Metadata.Ecma335;

namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan {get;set;}
        public string Nama {get;set;}
        public string Posisi {get;set;}

        public Karyawan(string nomorkaryawan, string nama, string posisi)
        {
            NomorKaryawan = nomorkaryawan;
            Nama = nama;
            Posisi = posisi;
        }
    }

    public class KaryawanNode
    {
        public Karyawan Karyawan {get;set;}
        public KaryawanNode Prev {get;set;}
        public KaryawanNode Next {get;set;}

        public KaryawanNode(Karyawan karyawan)
        {
            Karyawan = karyawan;
            Prev = null;
            Next = null;
        }
    }

    public class DaftarKaryawan
    {
        private KaryawanNode head;
        private KaryawanNode tail;

        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newNode = new KaryawanNode(karyawan);
            if(head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public bool HapusKaryawan(string nomorkaryawan)
        {
            KaryawanNode current = head;
            while(current != null)
            {
                if(current.Karyawan.NomorKaryawan == nomorkaryawan)
                {
                    if(current.Prev != null) current.Prev.Next = current.Next;
                    else head = current.Next;

                    if(current.Next != null) current.Next.Prev = current.Prev;
                    else tail = current.Prev;

                    current.Prev = null;
                    current.Next = null;

                    return true;
                }
                
                current = current.Next;
            }

            return false;
        }

        public Karyawan[] CariKaryawan(string kataKunci)
        {
            List<Karyawan> hasilPencarian = new List<Karyawan>();
            KaryawanNode current = head;
            while(current != null)
            {
                if(current.Karyawan.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) || 
                current.Karyawan.Posisi.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
                {
                    hasilPencarian.Add(current.Karyawan);
                }

                current = current.Next;
            }

            return hasilPencarian.ToArray();
        }

        public string TampilkanDaftar()
        {
            if(tail == null) return string.Empty;

            System.Text.StringBuilder output = new System.Text.StringBuilder();
            KaryawanNode current = tail;

            while(current != null)
            {
                output.AppendLine($"{current.Karyawan.NomorKaryawan}; {current.Karyawan.Nama}; {current.Karyawan.Posisi}");
                current = current.Prev;
            }

            return output.ToString().Trim();
        }

    }
}