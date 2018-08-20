CREATE OR REPLACE PACKAGE Da_Ref_List AS
/******************************************************************************
   NAME:       DA_REF_LIST
   PURPOSE:

   REVISIONS:
   Ver        Date        Author           Description
   ---------  ----------  ---------------  ------------------------------------
   1.0        07/16/2008             1. Created this package.
******************************************************************************/

  TYPE sqlcur IS REF CURSOR; 

  PROCEDURE REF_LIST_RA(
      IN_LIST_NAME IN VARCHAR,
      IN_FILTER IN VARCHAR,
      CUR_OUT OUT Da_Ref_List.sqlcur
      );

END Da_Ref_List;
/


CREATE OR REPLACE PACKAGE BODY Da_Ref_List AS
/******************************************************************************
   NAME:       DA_REF_LIST
   PURPOSE:

   REVISIONS:
   Ver        Date        Author           Description
   ---------  ----------  ---------------  ------------------------------------
   1.0        07/16/2008             1. Created this package.
******************************************************************************/

  PROCEDURE REF_LIST_RA(
      IN_LIST_NAME IN VARCHAR,
      IN_FILTER IN VARCHAR,
      CUR_OUT OUT Da_Ref_List.sqlcur
      ) IS
  BEGIN
  
  /***
  NOTE: Be sure to name the returned columns as below (KEY, VALUE, etc)
  ***/  
  CASE UCASE(IN_LIST_NAME)

      /* SAMPLE */
      WHEN 'LIABILITYMANAGEMENTSTATUS' THEN
      OPEN cur_out FOR 
      SELECT  
            CODES.CODE AS KEY,
            CODES.DESCRIPTION AS VALUE,
            NULL AS CREATED_BY,
            NULL AS CREATED_DATE,
            NULL AS CHANGED_BY,
            NULL AS CHANGED_DATE
      FROM  
           CODES
      WHERE CODES.LISTNAME='LMS'
      ORDER BY KEY;
      
  END CASE;
  
  END;

END Da_Ref_List;
/


