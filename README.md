# TCP_Suchary

## Wymagania Funkcjonalne

Serwer TCP wysyła instrukcję obsługi do klienta. Następnie czeka na ciąg znaków przesyłany od klienta.<br/>
Gdy otrzyma komunikat "suchar", serwer wysyła losowo wybrany z puli prosty żart (tzw. suchar). Komunikat "quit" rozłącza połączenie klienta, co uwalnia serwer i pozwala podłączyć się nowemu klientowi. Komunikat "shutdown" zamyka połączenie i wyłącza serwer.

Wiadomości przesyłane są jako kodowaniem UTF-8. Adres IP oraz Port są aktualnie na sztywno przypisane jako 127.0.0.1 oraz 8008. Wielkość buforu również jest stała. Serwer może na raz obsłużyć jedno połączenie.

## Wymagania Pozafunkcjonalne

Aplikacja zbudowana została w oparciu o .NET Core 3.1.4 (na systemie MacOS nie mam dostępu do .NET Framework). Jest on wymagany do uruchomienia aplikacji. Serwer pracuje synchronicznie.

Serwer testowany był poprzez narzędzie Netcat (odpowiednik PuTTy dla MacOS) i jest z nim w pełni kompatybilny.
