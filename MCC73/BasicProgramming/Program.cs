namespace BasicProgramming
{
    class Program
    {
        static string[] makanan = { "Pecel Lele", "Opor Ayam", "Bakso Bakar", "Sate Ayam" };
        static int[] harga = { 20000, 15000, 10000, 12000 };
        static int[] nomormakanan = { };
        static int[] jumlah = { };
        public static void Main(String[] args)
        {
            MenuUtama();
        }

        static void MenuUtama()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|| Selamat Datang Di Rumah Makan Murah ||");
            Console.WriteLine("=========================================");
            Console.WriteLine("|| 1. Lihat Menu Makanan               ||");
            Console.WriteLine("|| 2. Keranjang                        ||");
            Console.WriteLine("|| 3. Bersihkan Keranjang              ||");
            Console.WriteLine("|| 4. Keluar Aplikasi                  ||");
            Console.WriteLine("=========================================");
            Console.Write("Masukkan Pilihan : ");
            int pilih = Convert.ToInt32(Console.ReadLine());
            switch (pilih)
            {
                case 1:
                    Katalog();
                    break;
                case 2:
                    Keranjang();
                    break;
                case 3:
                    HapusPesanan();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("Pilihan Yang Anda Masukkan Tidak Ada !!!");
                    Console.WriteLine("========================================");
                    Console.ReadKey();
                    Console.Clear();
                    MenuUtama();
                    break;
            }
        }
        static void ListBarang()
        {
            Console.Clear();
            int no = 1;
            Console.WriteLine("==========================================");
            Console.WriteLine("||No|| Nama Barang\t|| Harga\t||");
            Console.WriteLine("||==||==================||==============||");
            for (int i = 0; i < makanan.Length; i++)
            {
                Console.WriteLine("||" + no++ + " || " + makanan[i] + "\t|| " + harga[i] + "\t||");
            }
            Console.WriteLine("==========================================");
        }
        static void Katalog()
        {
            ListBarang();
            Boolean ulang = false;
            do
            {
                Console.Write("Apakah Anda akan membeli makanan ? y/n : ");
                string lanjut = Console.ReadLine().ToLower();
                switch (lanjut)
                {
                    case "y":
                        Beli();
                        break;
                    case "n":
                        Console.Clear();
                        MenuUtama();
                        break;
                    default:
                        Katalog();
                        break;
                }
            } while (ulang == true);
        }

        static void Beli()
        {
            Console.Clear();
            ListBarang();
            Console.Write("Ingin Membeli Nomor Berapa ? : ");
            int pilih_barang = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Ingin Membeli Berapa ? : ");
            int pilih_jumlah = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("==========================================");
            Console.WriteLine("||\tPemesanan Makanan\t\t||");
            Console.WriteLine("==========================================");
            Console.WriteLine("|| Nama Makanan\t= {0}\t\t||",makanan[pilih_barang]);
            Console.WriteLine("|| Harga Barang = {0}\t\t\t||",harga[pilih_barang]);
            Console.WriteLine("|| Total Harga \t= {0}\t\t\t||",JumlahHarga(harga[pilih_barang], pilih_jumlah));
            Console.WriteLine("==========================================");
            Console.Write("Apakah Pembelian Sudah Benar ? y/n : ");
            string lanjut = Console.ReadLine().ToLower();
            switch (lanjut)
            {
                case "y":
                    nomormakanan = nomormakanan.Append(pilih_barang).ToArray();
                    jumlah = jumlah.Append(pilih_jumlah).ToArray();
                    Console.Write("Apakah Ingin Membeli Makanan Baru ? y/n : ");
                    string beli_ulang = Console.ReadLine().ToLower();
                    if (beli_ulang == "y")
                    {
                        Beli();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("===========================================");
                        Console.WriteLine("Makanan sudah dimasukkan ke dalam keranjang");
                        Console.WriteLine("===========================================");
                        Console.ReadKey();
                        Console.Clear();
                        MenuUtama();
                    }
                    break;
                case "n":
                    Beli();
                    break;
                default:
                    Beli();
                    break;
            }
        }

        static void Keranjang()
        {
            Console.Clear();
            int no = 1;
            if (nomormakanan.Length != 0)
            {
                Console.WriteLine("\tMakanan yang ada di keranjang");
                Console.WriteLine("========================================================================");
                Console.WriteLine("||No|| Nama Makanan\t|| Harga\t|| Jumlah\t|| Total Harga||");
                Console.WriteLine("||==||==================||============================================||");
                for (int i = 0; i < nomormakanan.Length; i++)
                {
                    Console.WriteLine("|| " + no++ + "|| " + makanan[nomormakanan[i]] + "\t|| "+ harga[nomormakanan[i]] + "\t|| " + jumlah[i] + "\t\t|| " + JumlahHarga(harga[nomormakanan[i]], jumlah[i]) + "      ||");
                }
                Console.WriteLine("||==||==================||============================================||");
                Console.WriteLine("|| Jumlah Total \t|| " + Total(nomormakanan, jumlah) + "\t\t\t\t      ||");
                Console.WriteLine("========================================================================");
                BayarSekarang();
            }
            else
            {
                Console.WriteLine("Anda Belum Membeli Makanan Apapun");
                Console.ReadKey();
                Console.Clear();
                MenuUtama();
            }
        }
        static void BayarSekarang()
        {
            Console.Write("Bayar Sekarang ? y/n : ");
            string bayar = Console.ReadLine().ToLower();
            switch (bayar)
            {
                case "y":
                    Checkout();
                    break;
                case "n":
                    Console.Clear();
                    MenuUtama();
                    break;
                default:
                    Keranjang();
                    break;
            } 
        }
        static void HapusPesanan()
        {
            Console.Write("Apakah Yakin Ingin Membersihkan Keranjang ? y/n : ");
            string lanjut = Console.ReadLine().ToLower();
            switch (lanjut)
            {
                case "y":
                    Console.Clear();
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Anda Sudah Menghapus Semua Pembelian Anda");
                    Console.WriteLine("===========================================");
                    Console.ReadKey();
                    Console.Clear();
                    nomormakanan = new int[] { };
                    jumlah = new int[] { };
                    MenuUtama();
                    break;
                case "n":
                    Console.Clear();
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Anda Tidak Jadi Menghapus Keranjang Anda");
                    Console.WriteLine("===========================================");
                    Console.ReadKey();
                    Console.Clear();
                    MenuUtama();
                    break;
                default:
                    MenuUtama();
                    break;
            }
        }

        static void Checkout()
        {
            int total = Total(nomormakanan, jumlah);
            Console.Write("Masukkan Jumlah Uang : ");
            int bayar = Convert.ToInt32(Console.ReadLine());
            if (bayar >= total)
            {
                Console.Clear();
                Console.WriteLine("Berikut Adalah Struk Pembayaran");
                Console.WriteLine("===================================");
                Console.WriteLine("|| Total Belanja : " + total + "\t ||");
                Console.WriteLine("|| Jumlah Uang   : " + bayar + "\t ||");
                Console.WriteLine("||===============================||");
                Console.WriteLine("|| Uang Kembali  : " + (bayar - total) + "\t ||");
                Console.WriteLine("===================================");
                Console.Write("Ingin Melanjutkan Ke Halaman Utama ? y/n : ");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "y":
                        Console.Clear();
                        nomormakanan = new int[] { };
                        jumlah = new int[] { };
                        MenuUtama();
                        break;
                    case "n":
                        Console.Clear();
                        Console.WriteLine("Terima Kasih Sudah Belanja di Warung Makan Murah");
                        Environment.Exit(0);
                        MenuUtama();
                        break;
                    default:
                        MenuUtama();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Mohon Maaf Uang Yang Anda Inputkan Kurang");
                Console.WriteLine("Ingin Melanjutkan Pembayaran ? y/n");
                string lanjut = Console.ReadLine();
                switch (lanjut)
                {
                    case "y":
                        Console.Clear();
                        Keranjang();
                        break;
                    case "n":
                        Console.Clear();
                        Console.WriteLine("Anda Tidak Jadi Membayar");
                        MenuUtama();
                        break;
                    default:
                        MenuUtama();
                        break;
                }
            }
        }

        static int JumlahHarga(int harga, int pcs)
        {
            int jumlah_harga = harga * pcs;
            return jumlah_harga;
        }

        static int Total(int[] array, int[] array2)
        {
            int jumlah = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int sjumlah = JumlahHarga(harga[array[i]], array2[i]);
                jumlah += sjumlah;
            }
            return jumlah;
        }
    }
}