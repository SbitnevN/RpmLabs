@echo off
chcp 65001 >nul
setlocal

if not exist "./databases" (
    mkdir "./databases"
)

set /p db_name="Введите имя базы данных (без расширения): "

sqlite3 "./databases/%db_name%.db" ""

echo База данных "%db_name%.db" успешно создана в папке ./databases!

endlocal
pause
