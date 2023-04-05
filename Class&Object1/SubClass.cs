using System;

public class nasabahprioritas : nasabah
{
    public double bunga;

    public void biodata()
    {
        Console.WriteLine("Biodata Nasabah Prioritas");
        Console.WriteLine("Nama :" + nama);
        Console.WriteLine("NIK :" + nik);
        Console.WriteLine("Alamat :" + alamat);
        Console.WriteLine("Pekerjaan :" + pekerjaan);
        Console.WriteLine("Saldo Rekening :" + saldo);
        Console.WriteLine("Bunga Tabungan :" + bunga);
    }

}

public class nasabah2
{
    public static void Main(string[] args)
    {
        nasabahprioritas bagas = new nasabahprioritas();

        bagas.nama = "Bagas Adi";
        bagas.nik = 33052104;
        bagas.alamat = "Bekasi";
        bagas.pekerjaan = "PNS";
        bagas.saldo = 74000000;
        bagas.bunga = 0.1;

        bagas.biodata();
    }
}
