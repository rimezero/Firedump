REM CALL firedump.exe stop
REM ECHO Stopping firedump Service
sc stop firedumpService3
TIMEOUT /T 3

sc start firedumpService3
TIMEOUT /T 2