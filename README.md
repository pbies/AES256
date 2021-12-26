AES256
======

		Simple AES256 file encrypter/decrypter

	Getting Started
	---------------

		1. Download the source code
		2. Run Visual Studio
		3. Open solution
		4. Build
		5. Run

	Prerequisites
	-------------

		Windows + Visual Studio

	Installing
	----------

		No need to install, runs out of the box.

	Running the tests
	-----------------

		No tests included.

	Purpose
	-------

		File encryption/decryption. Max is 4 GiB per file.

		You may drag & drop files to buttons or click the buttons to open file dialog.

	Built With
	----------

		Visual Studio Community

	Contributing
	------------

		Edits are allowed on separate branches.

	Versioning
	----------

		When there will be new version, the old one will be overwritten.

	To do
	-----

		For FAT32 there is limit to 4 GiB for a file. In this case after encryption file can be
		too big to save, so need to lower the limit for few bytes to keep the AES256 checksum.

		On most of other filesystems there is no problem with files larger than 4 GiB, but you
		must have enough RAM or swap space for whole file. Or even two such files - not tested.

	Authors
	-------

		Piotr Biesiada - Initial work

	License
	-------

		This project is licensed under the GNU GENERAL PUBLIC LICENSE - see the
		LICENSE file for details.

		That means you must fulfill these requirements:
		1. your project have the same license
		2. you mention the original author (me)
		3. can't use scripts in commercial products if they are not free
		4. you can freely modify and use this project for personal usage

	Acknowledgments
	---------------

		If you like my work please share your opinion with me!

		ptrbsd gmail
