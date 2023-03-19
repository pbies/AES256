using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AES256
{
    public partial class Form1 : Form
    {
        private long limit = 4294967296;

        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        byte[] saltBytes = new byte[] { 0xe9, 0x6c, 0xcf, 0x45, 0xe9, 0x6c, 0xcf, 0x45 }; // CRC32 for space twice


        public Form1()
        {
            InitializeComponent();
        }

        private void EncryptBtn_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                try
                {
                    EncryptFile(file, textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nFilename: " + file);
                }
            }
        }

        private void EncryptBtn_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public void EncryptFile(string fileToEncrypt, string password)
        {
            if (new FileInfo(fileToEncrypt).Length > limit)
            {
                MessageBox.Show("File too long! 4GB is max!");
                return;
            }

            byte[] bytesToBeEncrypted = File.ReadAllBytes(fileToEncrypt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string fileEncrypted = fileToEncrypt + ".aes256";

            File.WriteAllBytes(fileEncrypted, bytesEncrypted);
        }

        public void DecryptFile(string fileEncrypted, string password)
        {
            if (new FileInfo(fileEncrypted).Length > limit)
            {
                MessageBox.Show("File too long! 4GB is max!");
                return;
            }

            byte[] bytesToBeDecrypted = File.ReadAllBytes(fileEncrypted);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string outputFileDecrypted = fileEncrypted.Substring(0, fileEncrypted.IndexOf(".aes256"));
            File.WriteAllBytes(outputFileDecrypted, bytesDecrypted);
        }

        private void DecryptBtn_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void DecryptBtn_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                try
                {
                    DecryptFile(file, textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nFilename: " + file);
                }
            }

        }

        private void EncryptBtn_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
                foreach (var fn in ofd.FileNames)
                    try
                    {
                        EncryptFile(fn, textBox1.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\nFilename: " + fn);
                    }
        }

        private void DecryptBtn_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
                foreach (var fn in ofd.FileNames)
                    try
                    {
                        DecryptFile(fn, textBox1.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\nFilename: " + fn);
                    }
        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AES256 file encrypter and decrypter\n© 2023 Piotr Biesiada\n\n4 GiB file size is max\nSalt is always the same\nYou may click the buttons to select files\nor drag & drop files to buttons", "AES256 v1.1");
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
