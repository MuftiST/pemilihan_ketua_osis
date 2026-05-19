-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 19, 2026 at 03:09 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pkk_mufti`
--

-- --------------------------------------------------------

--
-- Table structure for table `calon_ketua`
--

CREATE TABLE `calon_ketua` (
  `ID_Ketua` int(11) NOT NULL,
  `NISN` int(11) NOT NULL,
  `Nama_Ketua` varchar(50) NOT NULL,
  `Kelas` varchar(50) NOT NULL,
  `ID_Pasangan` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `calon_ketua`
--

INSERT INTO `calon_ketua` (`ID_Ketua`, `NISN`, `Nama_Ketua`, `Kelas`, `ID_Pasangan`) VALUES
(1, 676767, 'ANIES BASWEDAN', 'XI RPL-B', 1),
(2, 678910, 'PRABOWO SUBIANTO', 'XI TKJ-B', 2),
(3, 671234, 'GANJAR PRANOWO', 'XI TPTU-A', 3),
(4, 678999, 'JOKO WIDODO', 'XI TEI-B', 4);

-- --------------------------------------------------------

--
-- Table structure for table `calon_pasangan`
--

CREATE TABLE `calon_pasangan` (
  `ID_Pasangan` int(11) NOT NULL,
  `ID_Ketua` int(11) NOT NULL,
  `ID_Wakil` int(11) NOT NULL,
  `Visi` text NOT NULL,
  `Misi` text NOT NULL,
  `Proker` text NOT NULL,
  `Jumlah_Suara` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `calon_pasangan`
--

INSERT INTO `calon_pasangan` (`ID_Pasangan`, `ID_Ketua`, `ID_Wakil`, `Visi`, `Misi`, `Proker`, `Jumlah_Suara`) VALUES
(1, 1, 1, 'Menjadikan OSIS sebagai wadah siswa yang aktif, kreatif, disiplin, dan peduli terhadap lingkungan sekolah', '1. Mengadakan kegiatan yang meningkatkan bakat dan minat siswa\r\n2. Menjalin kerja sama yang baik antar siswa dan guru', '1. Class meeting antar kelas\r\n2. Program Jumat bersih\r\n3. Lomba kreativitas siswa\r\n4. Membantu rakyat kurang mampu', 5),
(2, 2, 2, 'Mewujudkan OSIS yang inovatif, modern, dan mampu menjadi inspirasi bagi seluruh siswa SMK', '1. Memanfaatkan tekhnologi dalam kegiatan OSIS\r\n2. Meningkatkan solidaritas antar angkatan', '1. Seminar dunia kerja & industri\r\n2. Turnamen E-Sport & Olahraga\r\n3. Pelatihan public speaking', 5),
(3, 3, 3, 'Menciptakan lingkungan sekolah yang nyaman, berprestasi, dan penuh rasa kekeluargaan', '1. Menumbuhkan sikap saling menghargai\r\n2. Mengadakan kegiatan sosial yang bermanfaat', '1. Bakti sosial dan donasi\r\n2. Program tutor sebaya\r\n3. Pentas seni sekolah\r\n4. Hari bebs bullying', 3),
(4, 4, 4, 'Menjadikan OSIS sebagai organisasi yang disiplin, bertanggung jawab, dan berjiwa kepemimpinan', '1. Menanamkan budaya disiplin di sekolah\r\n2. Meningkatkan semangat belajar dan prestasi siswa', '1. Pelatihan leadership siswa\r\n2. Program siswa teladan bulanan\r\n3. Kompetisi antar kelas\r\n4. Program literasi dan pojok baca sekolah', 2);

-- --------------------------------------------------------

--
-- Table structure for table `calon_wakil`
--

CREATE TABLE `calon_wakil` (
  `ID_Wakil` int(11) NOT NULL,
  `NISN` int(11) NOT NULL,
  `Nama_Wakil` varchar(50) NOT NULL,
  `Kelas` varchar(20) NOT NULL,
  `ID_Pasangan` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `calon_wakil`
--

INSERT INTO `calon_wakil` (`ID_Wakil`, `NISN`, `Nama_Wakil`, `Kelas`, `ID_Pasangan`) VALUES
(1, 2147483647, 'MUHAIMIN', 'XI TPTU-A', 1),
(2, 98687565, 'GIBRAN RAKABUMING', 'XI TKJ-B', 2),
(3, 986875753, 'MAHFUD MD', 'XI TEI-A', 3),
(4, 98645463, 'JUSUF KALLA', 'XI TEI-C', 4);

-- --------------------------------------------------------

--
-- Table structure for table `panitia`
--

CREATE TABLE `panitia` (
  `NISN` int(11) NOT NULL,
  `Nama_Lengkap` varchar(50) NOT NULL,
  `Kelas` varchar(20) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Hak` enum('Admin','Pemilih') NOT NULL,
  `Status_Memilih` varchar(20) DEFAULT 'Belum'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `panitia`
--

INSERT INTO `panitia` (`NISN`, `Nama_Lengkap`, `Kelas`, `Username`, `Password`, `Hak`, `Status_Memilih`) VALUES
(10001, 'Andi Setiawan', 'XI TKJ', 'andi01', 'pass01', 'Pemilih', 'Sudah'),
(10002, 'Budi Santoso', 'XI TKJ', 'budi02', 'pass02', 'Pemilih', 'Sudah'),
(10003, 'Citra Dewi', 'XI TKJ', 'citra03', 'pass03', 'Pemilih', 'Sudah'),
(10004, 'Deni Pratama', 'XI TKJ', 'deni04', 'pass04', 'Pemilih', 'Sudah'),
(10005, 'Eka Lestari', 'XI TKJ', 'eka05', 'pass05', 'Pemilih', 'Sudah'),
(10006, 'Fajar Nugraha', 'XI RPL', 'fajar06', 'pass06', 'Pemilih', 'Sudah'),
(10007, 'Gita Maharani', 'XI RPL', 'gita07', 'pass07', 'Pemilih', 'Sudah'),
(10008, 'Hadi Saputra', 'XI RPL', 'hadi08', 'pass08', 'Pemilih', 'Sudah'),
(10009, 'Indah Permata', 'XI RPL', 'indah09', 'pass09', 'Pemilih', 'Sudah'),
(10010, 'Joko Susilo', 'XI RPL', 'joko10', 'pass10', 'Pemilih', 'Sudah'),
(10011, 'Kiki Ramadhan', 'XI TPTU', 'kiki11', 'pass11', 'Pemilih', 'Belum'),
(10012, 'Lina Kartika', 'XI TPTU', 'lina12', 'pass12', 'Pemilih', 'Belum'),
(10013, 'Maya Sari', 'XI TPTU', 'maya13', 'pass13', 'Pemilih', 'Belum'),
(10014, 'Nanda Putra', 'XI TPTU', 'nanda14', 'pass14', 'Pemilih', 'Belum'),
(10015, 'Oki Firmansyah', 'XI TPTU', 'oki15', 'pass15', 'Pemilih', 'Belum'),
(10016, 'Putri Ayu', 'XI TEI A', 'putri16', 'pass16', 'Pemilih', 'Belum'),
(10017, 'Rizky Hidayat', 'XI TEI A', 'rizky17', 'pass17', 'Pemilih', 'Belum'),
(10018, 'Sinta Dewi', 'XI TEI A', 'sinta18', 'pass18', 'Pemilih', 'Belum'),
(10019, 'Tono Wijaya', 'XI TEI A', 'tono19', 'pass19', 'Pemilih', 'Belum'),
(10020, 'Umi Rahma', 'XI TEI A', 'umi20', 'pass20', 'Pemilih', 'Belum'),
(10021, 'Vina Oktaviani', 'XI TEI B', 'vina21', 'pass21', 'Pemilih', 'Belum'),
(10022, 'Wawan Gunawan', 'XI TEI B', 'wawan22', 'pass22', 'Pemilih', 'Belum'),
(10023, 'Xenia Laras', 'XI TEI B', 'xenia23', 'pass23', 'Pemilih', 'Belum'),
(10024, 'Yoga Prasetyo', 'XI TEI B', 'yoga24', 'pass24', 'Pemilih', 'Belum'),
(10025, 'Zahra Amalia', 'XI TEI B', 'zahra25', 'pass25', 'Pemilih', 'Belum'),
(10026, 'Bayu Kurniawan', 'XI TEI C', 'bayu26', 'pass26', 'Pemilih', 'Belum'),
(10027, 'Cindy Oktora', 'XI TEI C', 'cindy27', 'pass27', 'Pemilih', 'Belum'),
(10028, 'Dimas Saputra', 'XI TEI C', 'dimas28', 'pass28', 'Pemilih', 'Belum'),
(10029, 'Evi Marlina', 'XI TEI C', 'evi29', 'pass29', 'Pemilih', 'Belum'),
(10030, 'Fikri Ananda', 'XI TEI C', 'fikri30', 'pass30', 'Pemilih', 'Belum'),
(10031, 'Galih Pratama', 'XI TKJ', 'galih31', 'pass31', 'Pemilih', 'Belum'),
(10032, 'Herlina Sari', 'XI RPL', 'herlina32', 'pass32', 'Pemilih', 'Belum'),
(10033, 'Iqbal Ramadhan', 'XI TPTU', 'iqbal33', 'pass33', 'Pemilih', 'Belum'),
(10034, 'Jihan Safira', 'XI TEI A', 'jihan34', 'pass34', 'Pemilih', 'Belum'),
(10035, 'Kevin Aditya', 'XI TEI B', 'kevin35', 'pass35', 'Pemilih', 'Belum'),
(10036, 'Laila Nur', 'XI TEI C', 'laila36', 'pass36', 'Pemilih', 'Belum'),
(10037, 'Miko Prasetyo', 'XI TKJ', 'miko37', 'pass37', 'Pemilih', 'Belum'),
(10038, 'Nabila Zahra', 'XI RPL', 'nabila38', 'pass38', 'Pemilih', 'Belum'),
(10039, 'Oscar Firmansyah', 'XI TPTU', 'oscar39', 'pass39', 'Pemilih', 'Belum'),
(10040, 'Putra Mahendra', 'XI TEI A', 'putra40', 'pass40', 'Pemilih', 'Belum'),
(10041, 'Qori Amalia', 'XI TEI B', 'qori41', 'pass41', 'Pemilih', 'Belum'),
(10042, 'Rani Oktaviani', 'XI TEI C', 'rani42', 'pass42', 'Pemilih', 'Belum'),
(10043, 'Samsul Arifin', 'XI TKJ', 'samsul43', 'pass43', 'Pemilih', 'Belum'),
(10044, 'Tasya Maharani', 'XI RPL', 'tasya44', 'pass44', 'Pemilih', 'Belum'),
(10045, 'Ujang Suryana', 'XI TPTU', 'ujang45', 'pass45', 'Pemilih', 'Belum'),
(10046, 'Vito Pradana', 'XI TEI A', 'vito46', 'pass46', 'Pemilih', 'Belum'),
(10047, 'Wulan Sari', 'XI TEI B', 'wulan47', 'pass47', 'Pemilih', 'Belum'),
(67555, 'Subhan', 'XI TPTU-A', 'subhan', 'sub13', 'Pemilih', 'Belum'),
(67888, 'Mufti Subhan toha', 'XI RPL-A', 'admin', 'admin123', 'Admin', 'Belum'),
(67999, 'Move', 'XI RPL-B', 'user', 'user123', 'Pemilih', 'Belum'),
(89678132, 'Mufti Subhan toha', 'XI RPL-D', 'muft10', '123', 'Pemilih', 'Belum');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `calon_ketua`
--
ALTER TABLE `calon_ketua`
  ADD PRIMARY KEY (`ID_Ketua`);

--
-- Indexes for table `calon_pasangan`
--
ALTER TABLE `calon_pasangan`
  ADD PRIMARY KEY (`ID_Pasangan`);

--
-- Indexes for table `calon_wakil`
--
ALTER TABLE `calon_wakil`
  ADD PRIMARY KEY (`ID_Wakil`);

--
-- Indexes for table `panitia`
--
ALTER TABLE `panitia`
  ADD PRIMARY KEY (`NISN`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
