---
CREATE   function usp_process(
    @DATA varchar(8000)
)
    returns varchar(8000)
AS
begin
    DECLARE @operacion VARCHAR(200);
    DECLARE @tabla VARCHAR(200);
    DECLARE @return VARCHAR(8000);
    DECLARE @username VARCHAR(8000);
    DECLARE @password VARCHAR(8000);

    select @operacion = JSON_VALUE(@DATA, '$.operacion');
    --RaisError(@operacion, 0,0);
    /*
    LOGIN OPERATION
    */
    if @operacion = 'login'
        begin
            select @username = JSON_VALUE(@DATA, '$.username');
            select @password = JSON_VALUE(@DATA, '$.password');

            if @username = 'admin' and @password = '1234'
                begin
                    set @return = '{"login":"OK"}';
                end
            else
                begin
                    set @return = '{"login":"FAIL"}';
                end
        end

    /*
    SELECT OPERATION
    */
    if @operacion = 'select'
        begin
            select @tabla = JSON_VALUE(@DATA, '$.tabla');

            if @tabla = 'tm_departamento'
                begin
                    select @return = (select * from TM_DEPARTAMENTO for json auto);
                end
            if @tabla = 'tm_proyecto'
                begin
                    select @return = (select * from TM_PROYECTO for json auto);
                end
        end

    return @return;
end
go

