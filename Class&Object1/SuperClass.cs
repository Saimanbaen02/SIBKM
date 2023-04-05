using System;

public class nasabah //Atribut
{
    public string nama;
    public int nik;
    public string alamat;
    public string pekerjaan;
    public int saldo;

    public void introduction() //Method
    {
        Console.WriteLine("Biodata Nasabah");
        Console.WriteLine("Nama :" + nama);
        Console.WriteLine("NIK :" + nik);
        Console.WriteLine("Alamat :" + alamat);
        Console.WriteLine("Pekerjaan :" + pekerjaan);
        Console.WriteLine("Saldo Rekening :" + saldo);
    }
}



