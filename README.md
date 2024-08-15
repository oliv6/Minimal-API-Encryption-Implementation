# Implementing AES and Blowfish encryption techniques in minimal API
<p> In this small project, I developed an encrypted minimal API using AES and Blowfish encryption techniques.</p>
<p>The Blowfish encryption algorithm is implemented with the support for ECB, CBC, and CTR modes. It initializes the algorithm with a key, sets up the S-boxes and P-array using values derived from Pi, and provides methods to encrypt and decrypt data. The EncryptBlowFish class handles key setup, block encryption/decryption, and mode-specific operations, including random IV generation for CBC and CTR modes.</p>
