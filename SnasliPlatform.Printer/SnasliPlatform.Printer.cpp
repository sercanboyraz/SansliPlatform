#include <Windows.h>
#include <stdio.h>
#include <string>

BOOL RawDataToPrinter()
{
	TBYTE statBuff[20];
	char buff2[1024];
	std::string z = "ITherm280";
	LPTSTR szPrinterName = new TCHAR[z.size() + 1];
	LPBYTE lpData = (LPBYTE)buff2;
	DWORD dwCount = sizeof(statBuff);
	HANDLE hPrinter;
	DOC_INFO_1 DocInfo;
	DWORD dwJob;
	DWORD dwBytesWritten;
	DWORD statLen = sizeof(statBuff);
	PRINTER_DEFAULTS hPrnDef = { 0 }; // pDatatype and pDevMode of structure are set to NULL
	hPrnDef.DesiredAccess = PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE;
	const WCHAR gszNoTranslateCRLF[] = L"TAReadStatus";
	// set desired access rights
	// Need a handle to the printer.
	if (!OpenPrinter(szPrinterName, &hPrinter, &hPrnDef))
	{
		printf("OpenPrinter abort error % d", GetLastError());
		return FALSE;
	}
	// Report on the status
	DWORD err = GetPrinterData(hPrinter, (LPWSTR)gszNoTranslateCRLF, NULL, (PBYTE)&statBuff, sizeof(statBuff), &statLen);
	printf("TAReadStatus read result %d; len %d:", err, statLen);
	for (WORD i = 0; i < statLen; i++)
		printf("%X ", statBuff[i]);
	printf("\n"); // Show the returned status in hex
	// Fill in the structure with info about this "document."
	DocInfo.pDocName = (LPWSTR)"My Document";
	DocInfo.pOutputFile = NULL;
	DocInfo.pDatatype = (LPWSTR)"RAW";
	// Inform the spooler the document is beginning.
	if ((dwJob = StartDocPrinter(hPrinter, 1, (LPBYTE)&DocInfo)) == 0)
	{
		printf("StartDocPrinter abort error % d", GetLastError());
		ClosePrinter(hPrinter);
		return FALSE;
	}
	// Start a page.
	if (!StartPagePrinter(hPrinter))
	{
		printf("StartPagePrinter abort error % d", GetLastError());
		EndDocPrinter(hPrinter);
		ClosePrinter(hPrinter);
		return FALSE;
	}
	// Send the data to the printer.
	if (!WritePrinter(hPrinter, lpData, dwCount, &dwBytesWritten))
	{
		printf("WritePrinter abort error % d", GetLastError());
		EndPagePrinter(hPrinter);
		EndDocPrinter(hPrinter);
		ClosePrinter(hPrinter);
		return FALSE;
	}
	// End the page.
	if (!EndPagePrinter(hPrinter))
	{
		printf("EndPagePrinter abort error % d", GetLastError());
		EndDocPrinter(hPrinter);
		ClosePrinter(hPrinter);
		return FALSE;
	}
	// Inform the spooler that the document is ending.
	if (!EndDocPrinter(hPrinter))
	{
		printf("EndDocPrinter abort error % d", GetLastError());
		ClosePrinter(hPrinter);
		return FALSE;
	}
	// Check to see if correct number of bytes were written.
	if (dwBytesWritten != dwCount)
	{
		printf(("Wrote %d bytes instead of requested %d bytes.\n"), dwBytesWritten, dwCount);
		ClosePrinter(hPrinter);
		//return FALSE; 
	}
	else printf("Entire file data was sent to printer.\n");
	// Show current printer status.
	statLen = sizeof(statBuff);
	err = GetPrinterData(hPrinter, (LPWSTR)gszNoTranslateCRLF, NULL, (PBYTE)&statBuff, sizeof(statBuff), &statLen);
	printf("TAReadStatus After print result %d; len %d:", err, statLen);
	for (WORD i = 0; i < statLen; i++) printf("%X ", statBuff[i]);
	printf("\n");
	// Tidy up the printer handle.
	ClosePrinter(hPrinter);
	return TRUE;
}

#include <cstdio>
//
//int main()
//{
//	RawDataToPrinter();
//	printf("hello from %s!\n", "SansliPlatform_Printer");
//	return 0;
//}

using namespace std;

int main()
{
	char test[] = "This is a test line to be printed.";

	LPHANDLE hPrinter;
	LPBYTE DocInfo;
	LPVOID Buff = test;
	DWORD read;
	LPDWORD written;

	OpenPrinter("HP DeskJet 712C", hPrinter, NULL);
	StartDocPrinter(hPrinter, 1, (LPBYTE)&DocInfo);
	StartPagePrinter(hPrinter);

	WritePrinter(hPrinter, Buff, read, written);

	EndPagePrinter(hPrinter);
	EndDocPrinter(hPrinter);
	ClosePrinter(hPrinter);

	count << "Test line sent to printer" << endl
		<< "Hit <enter> to end";
	cin.get();
	return 0;
}