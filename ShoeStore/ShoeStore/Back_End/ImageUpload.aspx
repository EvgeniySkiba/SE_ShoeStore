<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageUpload.aspx.cs" Inherits="ShoeStore.Back_End.ImageUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<html lang="en" class="no-js">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>Добавление товара</title>
    <!--[if lt IE 9]>
<script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/themes/base/jquery-ui.css"
        id="theme" />
    <link rel="stylesheet" href="../styles/Default/jquery.fileupload-ui.css" />
    <link rel="stylesheet" href="../styles/Default/style.css" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/jquery-ui.min.js"></script>
    <script src="//ajax.aspnetcdn.com/ajax/jquery.templates/beta1/jquery.tmpl.min.js"></script>
    <script src="../scripts/Default/jquery.iframe-transport.js"></script>
    <script src="../scripts/Default/jquery.fileupload.js"></script>
    <script src="../scripts/Default/jquery.fileupload-ui.js"></script>
    <script src="../scripts/Default/application.js"></script>
    <script id="template-upload" type="text/x-jquery-tmpl">

    <tr class="template-upload{{if error}} ui-state-error{{/if}}">
        <td class="preview"></td>
        <td class="name">${name}</td>
        <td class="size">${sizef}</td>
        {{if error}}
            <td class="error" colspan="2">Error:
                {{if error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
       
            <td class="progress"><div></div></td>
            <td class="start"><button>Start</button></td>
        {{/if}}
        <td class="cancel"><button>Cancel</button></td>
    </tr>
    </script>
    <script id="template-download" type="text/x-jquery-tmpl">
    <tr class="template-download{{if error}} ui-state-error{{/if}}">
        {{if error}}
            <td></td>
            <td class="name">${name}</td>
            <td class="size">${sizef}</td>
            <td class="error" colspan="2">Error:
                {{if error === 1}}File exceeds upload_max_filesize (php.ini directive)
                {{else error === 2}}File exceeds MAX_FILE_SIZE (HTML form directive)
                {{else error === 3}}File was only partially uploaded
                {{else error === 4}}No File was uploaded
                {{else error === 5}}Missing a temporary folder
                {{else error === 6}}Failed to write file to disk
                {{else error === 7}}File upload stopped by extension
                {{else error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else error === 'uploadedBytes'}}Uploaded bytes exceed file size
                {{else error === 'emptyResult'}}Empty file upload result
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
            <td class="preview">
                {{if thumbnail_url}}
                    <a href="${url}" target="_blank"><img src="${thumbnail_url}"></a>
                {{/if}}
            </td>
            <td class="name">
                <a href="${url}"{{if thumbnail_url}} target="_blank"{{/if}}>${name}</a>
            </td>
            <td class="size">${sizef}</td>
            <td colspan="2"></td>
        {{/if}}
        <td class="delete">
            <button data-type="${delete_type}" data-url="${delete_url}">Delete</button>
        </td>
    </tr>
    </script>
</head>
<body>
   <fieldset id="imageUpload" style="width:750px;">
            <legend>Загрузка изображения </legend>
            <div id="fileupload">


                <form id="Form1" action="../FileTransferHandler.ashx" method="POST" enctype="multipart/form-data">

                
                <div class="fileupload-buttonbar">
                    <label class="fileinput-button">
                        <span>Add files...</span>
                        <input type="file" name="files[]" multiple="multiple" />
                    </label>
                    <button type="button" class="delete button">
                        Delete all files</button>
                    <button type="submit" class="start">
                        Start upload</button>
                    <button type="reset" class="cancel">
                        Cancel upload</button>
                    <button type="button" class="delete">
                        Delete files</button>                           
                    <div class="fileupload-progressbar">
                    </div>
                </div>
                </form>
                <div class="fileupload-content">
                    <table class="files">
                    </table>
                </div>
            </div>
        </fieldset>

        <br />

        <a href=Product.aspx >к списку товаров</a>
</body>
</html>
