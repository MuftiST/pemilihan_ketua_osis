🗳️ Panduan Migrasi ke Putaran 2 — Aplikasi Pemilihan
Dokumentasi langkah-langkah untuk mengonfigurasi aplikasi pemilihan agar siap digunakan pada Putaran 2.
---
01 — Reset Status Pemilih
> ⚠️ **Wajib dilakukan sebelum Putaran 2 dimulai.** Pastikan semua pemilih di database direset agar status kembali menjadi `'Belum'`.
Jalankan query berikut di database aplikasi:
```sql
UPDATE panitia SET Status_Memilih = 'Belum';
```
Verifikasi hasilnya:
```sql
SELECT COUNT(*) FROM panitia WHERE Status_Memilih = 'Belum';
```
Pastikan jumlah yang dikembalikan sesuai dengan total data pemilih yang terdaftar.
---
02 — Buka Project
Mulai dengan membuka project aplikasi di Visual Studio 2019.
Jalankan Visual Studio 2019
Buka file `.sln` project aplikasi pemilihan
---
03 — Akses Form Login
Form login adalah titik masuk aplikasi dan perlu dimodifikasi untuk mengarahkan pengguna ke form Putaran 2.
Di Solution Explorer, cari file `Form Login`
Klik dua kali untuk membuka tampilan desain (Design View)
---
04 — Modifikasi Event Tombol Login
Ubah alur navigasi agar setelah login, aplikasi mengarah ke form Putaran 2.
Klik dua kali tombol Login / Masuk di tampilan desain
Pada code view, ubah kode berikut:
```csharp
// ❌ Sebelumnya
pilih_paslon frm = new pilih_paslon();
frm.Show();
```
```csharp
// ✅ Menjadi
pilih_paslon_putaran2 frm = new pilih_paslon_putaran2();
frm.Show();
```
---
05 — Update Data Paslon Baru
Form `pilih_paslon_putaran2` harus menampilkan data paslon yang sesuai dengan Putaran 2.
Buka form `pilih_paslon_putaran2`
Perbarui nama paslon melalui Properties Window atau langsung di kode
Ganti foto paslon sesuai data Putaran 2 (gunakan komponen `PictureBox`)
Sesuaikan nomor urut jika ada perubahan
Pastikan semua perubahan tersimpan
> 💡 **Tips:** Jika data paslon diambil dari database, arahkan query ke tabel atau record khusus Putaran 2.
---
06 — Build & Run Project
Uji coba untuk memastikan semua konfigurasi berjalan dengan benar.
Lakukan Build project (`Ctrl + Shift + B`)
Jalankan aplikasi (`F5`)
Login dan pastikan diarahkan ke form `pilih_paslon_putaran2`
Verifikasi data paslon tampil sesuai dengan Putaran 2
---
📌 Catatan Penting
Pastikan form `pilih_paslon_putaran2` sudah ada di project sebelum mengubah redirect di form login.
Gunakan Properties Window untuk update cepat pada label dan `PictureBox`.
Jika data paslon diambil dari database, pastikan query diarahkan ke tabel/record khusus Putaran 2.
Lakukan backup database sebelum menjalankan query `UPDATE`.
---
🛠️ Teknologi
IDE: Visual Studio 2019
Bahasa: C# (.NET / Windows Forms)
Database: SQL (sesuaikan dengan DBMS yang digunakan)
