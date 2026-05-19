Langkah Konfigurasi Putaran 2
1. Buka Project
Jalankan Visual Studio 2019.

Buka file project aplikasi pemilihan Anda.

2. Akses Form Login
Pada Solution Explorer, cari file Form Login.

Klik dua kali untuk membuka tampilan desain form.

3. Modifikasi Event Tombol Login
Di tampilan desain, klik dua kali tombol Login/Masuk.

Anda akan diarahkan ke code view.

Ubah alur navigasi setelah login berhasil:

csharp
// Sebelumnya
pilih_paslon frm = new pilih_paslon();
frm.Show();

// Menjadi
pilih_paslon_putaran2 frm = new pilih_paslon_putaran2();
frm.Show();
4. Update Data Paslon Baru
Buka form pilih_paslon_putaran2 (klik dua kali file tersebut).

Pada area form atau komponen terkait:

Perbarui nama paslon di Properties atau langsung di kode.

Ganti foto paslon sesuai data Putaran 2.

Sesuaikan nomor urut jika ada perubahan.

Pastikan semua data paslon Putaran 2 sudah tersimpan dengan benar.

📌 Catatan Penting
Pastikan form pilih_paslon_putaran2 sudah ditambahkan ke project sebelum melakukan redirect.

Lakukan build & run untuk menguji apakah login berhasil diarahkan ke form Putaran 2.

Gunakan Properties Window untuk update cepat (misalnya mengganti teks label atau gambar PictureBox).

Jika data paslon diambil dari database, pastikan query sudah diarahkan ke tabel/record khusus Putaran 2.
