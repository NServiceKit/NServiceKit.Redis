REM SET BUILD=Debug
SET BUILD=Release

COPY ..\src\NServiceKit.Redis\bin\%BUILD%\NServiceKit.Redis.* ..\NuGet\lib\net35

COPY ..\src\NServiceKit.Redis\bin\%BUILD%\NServiceKit.* ..\..\NServiceKit\release\latest\NServiceKit.Redis

COPY ..\src\NServiceKit.Redis\bin\%BUILD%\NServiceKit.* ..\..\NServiceKit\lib
COPY ..\src\NServiceKit.Redis\bin\%BUILD%\NServiceKit.* ..\..\NServiceKit.Examples\lib
COPY ..\src\NServiceKit.Redis\bin\%BUILD%\NServiceKit.Redis.* ..\..\NServiceKit.Contrib\lib
COPY ..\src\NServiceKit.Redis\bin\%BUILD%\NServiceKit.Redis.* ..\..\NServiceKit.RedisWebServices\lib


