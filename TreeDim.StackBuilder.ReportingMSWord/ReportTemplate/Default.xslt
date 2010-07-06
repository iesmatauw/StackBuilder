<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pkg="http://schemas.microsoft.com/office/2006/xmlPackage" xmlns:ve="http://schemas.openxmlformats.org/markup-compatibility/2006" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing" xmlns:w10="urn:schemas-microsoft-com:office:word" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main" xmlns:wne="http://schemas.microsoft.com/office/word/2006/wordml" xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:sl="http://schemas.openxmlformats.org/schemaLibrary/2006/main" xmlns:ds="http://schemas.openxmlformats.org/officeDocument/2006/customXml" xmlns:b="http://schemas.openxmlformats.org/officeDocument/2006/bibliography" xmlns:cp="http://schemas.openxmlformats.org/package/2006/metadata/core-properties" xmlns:dc="http://purl.org/dc/elements/1.1/" xmlns:dcterms="http://purl.org/dc/terms/" xmlns:dcmitype="http://purl.org/dc/dcmitype/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:tns="http://schemas.microsoft.com/office/2006/customDocumentInformationPanel" xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes" xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
  <xsl:output method="xml" encoding="UTF-8" standalone="yes" />
  <xsl:template match="/">
    <xsl:processing-instruction name="mso-application">
      <xsl:text>progid="Word.Document"</xsl:text>
    </xsl:processing-instruction>
    <pkg:package xmlns:pkg="http://schemas.microsoft.com/office/2006/xmlPackage">
      <pkg:part pkg:name="/_rels/.rels" pkg:contentType="application/vnd.openxmlformats-package.relationships+xml" pkg:padding="512">
        <pkg:xmlData>
          <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
            <Relationship Id="rId3" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties" Target="docProps/app.xml" />
            <Relationship Id="rId2" Type="http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties" Target="docProps/core.xml" />
            <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="word/document.xml" />
          </Relationships>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/word/_rels/document.xml.rels" pkg:contentType="application/vnd.openxmlformats-package.relationships+xml" pkg:padding="256">
        <pkg:xmlData>
          <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
            <Relationship Id="rId8" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/image" Target="media/image3.png" />
            <Relationship Id="rId3" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles" Target="styles.xml" />
            <Relationship Id="rId7" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/image" Target="media/image2.png" />
            <Relationship Id="rId2" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml" Target="../customXml/item2.xml" />
            <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml" Target="../customXml/item1.xml" />
            <Relationship Id="rId6" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/image" Target="media/image1.png" />
            <Relationship Id="rId11" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme" Target="theme/theme1.xml" />
            <Relationship Id="rId5" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/webSettings" Target="webSettings.xml" />
            <Relationship Id="rId10" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/fontTable" Target="fontTable.xml" />
            <Relationship Id="rId4" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/settings" Target="settings.xml" />
            <Relationship Id="rId9" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/image" Target="media/image4.png" />
          </Relationships>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/word/document.xml" pkg:contentType="application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml">
        <pkg:xmlData>
          <xsl:apply-templates select="w:document" />
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/word/media/image2.png" pkg:contentType="image/png" pkg:compression="store">
        <pkg:binaryData>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</pkg:binaryData>
      </pkg:part>
      <pkg:part pkg:name="/word/media/image1.png" pkg:contentType="image/png" pkg:compression="store">
        <pkg:binaryData>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
CEAAAvUI/B9LEONsROoVawAAAABJRU5ErkJggg==</pkg:binaryData>
      </pkg:part>
      <pkg:part pkg:name="/word/media/image3.png" pkg:contentType="image/png" pkg:compression="store">
        <pkg:binaryData>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</pkg:binaryData>
      </pkg:part>
      <pkg:part pkg:name="/word/media/image4.png" pkg:contentType="image/png" pkg:compression="store">
        <pkg:binaryData>iVBORw0KGgoAAAANSUhEUgAAAgAAAAIACAIAAAB7GkOtAAAAAXNSR0IArs4c6QAAHTxJREFUeF7t
3c+L3HWaB/COiY2bDSPM3UMCEQ8h/4LgqMMQEPSQuzCQgcHLesjFo5ccnMswMAHBuweFBZFxMwH/
hZCDGDY5eBdmyGRCb9T9dnVX1bf6d9LdT57q9yvksGuq6vM8r3dPvZP6ubLiFwECBAhECpwatv7l
l18id7c0AQIEcgVOnTr1Qu72NidAgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgECyiA4PCtToBAtoACyM7f9gQIBAsogODw
rU6AQLaAAsjO3/YECAQLKIDg8K1OgEC2gALIzt/2BAgEC5wadv/ll1+CBax+NAJrH158+PmWm3rv
3A83Vo/m5ldGt39UN3v74St/W12c8BhOOaL93QyBoxY4deqUfwEcNWre7f10890fX9l+7z9AfPHw
lYs/Xvn0p3YmDx5fufjjK9fW2g1mIAKlAgqglPsEHnbr+j8+vrvXXndu/KNXBwz3/m8/unMCo7AS
gacVUABPK+byY4HbD9//Yn+ROzf+fWv/S3W4xOon9379w8bvI3vwqsNeZiCwo4AC8INxCIH793+e
X/vS2W9n957D//HN2cvzP1v7+vYhjnFVAgSORUABHAtryo3ev/dkuuqZj/700oXx3udf+urm/Bng
7+7v/EzArevD8wfj3w+f7t8KG4/mT35vfaBphz+aPF0xfvxn8izF8PvDzX4angSeDnN952cIDjrw
/PR/3nyw7rJ4xc3/mPKDYs+mAgqgaTDLMdaFi2emgz75+L8e398y9RvnNh9Ouffrr35/essf3v/0
n8M977ZHkNbeH+6C3912Uw08nn3gSRksbvrk47dbPj3ewNkIhQIKoBD75B114Ter88d57j56feOv
zwe4+x7uTF+/MfvXwzaY4aYOcCOVnocY+MnH13Z+zvnOjX9t/OPALwLPSUABPCf4E3Ls+Zf+fH32
j4DpTrMmmD+0srjug8cfjO79r96cPu9679zV2QXvPvrg6F8/evral4tPTgxvKZg8b/HJG3sGcviB
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</pkg:binaryData>
      </pkg:part>
      <pkg:part pkg:name="/word/theme/theme1.xml" pkg:contentType="application/vnd.openxmlformats-officedocument.theme+xml">
        <pkg:xmlData>
          <a:theme name="Office Theme" xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
            <a:themeElements>
              <a:clrScheme name="Office">
                <a:dk1>
                  <a:sysClr val="windowText" lastClr="000000" />
                </a:dk1>
                <a:lt1>
                  <a:sysClr val="window" lastClr="FFFFFF" />
                </a:lt1>
                <a:dk2>
                  <a:srgbClr val="1F497D" />
                </a:dk2>
                <a:lt2>
                  <a:srgbClr val="EEECE1" />
                </a:lt2>
                <a:accent1>
                  <a:srgbClr val="4F81BD" />
                </a:accent1>
                <a:accent2>
                  <a:srgbClr val="C0504D" />
                </a:accent2>
                <a:accent3>
                  <a:srgbClr val="9BBB59" />
                </a:accent3>
                <a:accent4>
                  <a:srgbClr val="8064A2" />
                </a:accent4>
                <a:accent5>
                  <a:srgbClr val="4BACC6" />
                </a:accent5>
                <a:accent6>
                  <a:srgbClr val="F79646" />
                </a:accent6>
                <a:hlink>
                  <a:srgbClr val="0000FF" />
                </a:hlink>
                <a:folHlink>
                  <a:srgbClr val="800080" />
                </a:folHlink>
              </a:clrScheme>
              <a:fontScheme name="Office">
                <a:majorFont>
                  <a:latin typeface="Cambria" />
                  <a:ea typeface="" />
                  <a:cs typeface="" />
                  <a:font script="Jpan" typeface="ＭＳ ゴシック" />
                  <a:font script="Hang" typeface="맑은 고딕" />
                  <a:font script="Hans" typeface="宋体" />
                  <a:font script="Hant" typeface="新細明體" />
                  <a:font script="Arab" typeface="Times New Roman" />
                  <a:font script="Hebr" typeface="Times New Roman" />
                  <a:font script="Thai" typeface="Angsana New" />
                  <a:font script="Ethi" typeface="Nyala" />
                  <a:font script="Beng" typeface="Vrinda" />
                  <a:font script="Gujr" typeface="Shruti" />
                  <a:font script="Khmr" typeface="MoolBoran" />
                  <a:font script="Knda" typeface="Tunga" />
                  <a:font script="Guru" typeface="Raavi" />
                  <a:font script="Cans" typeface="Euphemia" />
                  <a:font script="Cher" typeface="Plantagenet Cherokee" />
                  <a:font script="Yiii" typeface="Microsoft Yi Baiti" />
                  <a:font script="Tibt" typeface="Microsoft Himalaya" />
                  <a:font script="Thaa" typeface="MV Boli" />
                  <a:font script="Deva" typeface="Mangal" />
                  <a:font script="Telu" typeface="Gautami" />
                  <a:font script="Taml" typeface="Latha" />
                  <a:font script="Syrc" typeface="Estrangelo Edessa" />
                  <a:font script="Orya" typeface="Kalinga" />
                  <a:font script="Mlym" typeface="Kartika" />
                  <a:font script="Laoo" typeface="DokChampa" />
                  <a:font script="Sinh" typeface="Iskoola Pota" />
                  <a:font script="Mong" typeface="Mongolian Baiti" />
                  <a:font script="Viet" typeface="Times New Roman" />
                  <a:font script="Uigh" typeface="Microsoft Uighur" />
                </a:majorFont>
                <a:minorFont>
                  <a:latin typeface="Calibri" />
                  <a:ea typeface="" />
                  <a:cs typeface="" />
                  <a:font script="Jpan" typeface="ＭＳ 明朝" />
                  <a:font script="Hang" typeface="맑은 고딕" />
                  <a:font script="Hans" typeface="宋体" />
                  <a:font script="Hant" typeface="新細明體" />
                  <a:font script="Arab" typeface="Arial" />
                  <a:font script="Hebr" typeface="Arial" />
                  <a:font script="Thai" typeface="Cordia New" />
                  <a:font script="Ethi" typeface="Nyala" />
                  <a:font script="Beng" typeface="Vrinda" />
                  <a:font script="Gujr" typeface="Shruti" />
                  <a:font script="Khmr" typeface="DaunPenh" />
                  <a:font script="Knda" typeface="Tunga" />
                  <a:font script="Guru" typeface="Raavi" />
                  <a:font script="Cans" typeface="Euphemia" />
                  <a:font script="Cher" typeface="Plantagenet Cherokee" />
                  <a:font script="Yiii" typeface="Microsoft Yi Baiti" />
                  <a:font script="Tibt" typeface="Microsoft Himalaya" />
                  <a:font script="Thaa" typeface="MV Boli" />
                  <a:font script="Deva" typeface="Mangal" />
                  <a:font script="Telu" typeface="Gautami" />
                  <a:font script="Taml" typeface="Latha" />
                  <a:font script="Syrc" typeface="Estrangelo Edessa" />
                  <a:font script="Orya" typeface="Kalinga" />
                  <a:font script="Mlym" typeface="Kartika" />
                  <a:font script="Laoo" typeface="DokChampa" />
                  <a:font script="Sinh" typeface="Iskoola Pota" />
                  <a:font script="Mong" typeface="Mongolian Baiti" />
                  <a:font script="Viet" typeface="Arial" />
                  <a:font script="Uigh" typeface="Microsoft Uighur" />
                </a:minorFont>
              </a:fontScheme>
              <a:fmtScheme name="Office">
                <a:fillStyleLst>
                  <a:solidFill>
                    <a:schemeClr val="phClr" />
                  </a:solidFill>
                  <a:gradFill rotWithShape="1">
                    <a:gsLst>
                      <a:gs pos="0">
                        <a:schemeClr val="phClr">
                          <a:tint val="50000" />
                          <a:satMod val="300000" />
                        </a:schemeClr>
                      </a:gs>
                      <a:gs pos="35000">
                        <a:schemeClr val="phClr">
                          <a:tint val="37000" />
                          <a:satMod val="300000" />
                        </a:schemeClr>
                      </a:gs>
                      <a:gs pos="100000">
                        <a:schemeClr val="phClr">
                          <a:tint val="15000" />
                          <a:satMod val="350000" />
                        </a:schemeClr>
                      </a:gs>
                    </a:gsLst>
                    <a:lin ang="16200000" scaled="1" />
                  </a:gradFill>
                  <a:gradFill rotWithShape="1">
                    <a:gsLst>
                      <a:gs pos="0">
                        <a:schemeClr val="phClr">
                          <a:shade val="51000" />
                          <a:satMod val="130000" />
                        </a:schemeClr>
                      </a:gs>
                      <a:gs pos="80000">
                        <a:schemeClr val="phClr">
                          <a:shade val="93000" />
                          <a:satMod val="130000" />
                        </a:schemeClr>
                      </a:gs>
                      <a:gs pos="100000">
                        <a:schemeClr val="phClr">
                          <a:shade val="94000" />
                          <a:satMod val="135000" />
                        </a:schemeClr>
                      </a:gs>
                    </a:gsLst>
                    <a:lin ang="16200000" scaled="0" />
                  </a:gradFill>
                </a:fillStyleLst>
                <a:lnStyleLst>
                  <a:ln w="9525" cap="flat" cmpd="sng" algn="ctr">
                    <a:solidFill>
                      <a:schemeClr val="phClr">
                        <a:shade val="95000" />
                        <a:satMod val="105000" />
                      </a:schemeClr>
                    </a:solidFill>
                    <a:prstDash val="solid" />
                  </a:ln>
                  <a:ln w="25400" cap="flat" cmpd="sng" algn="ctr">
                    <a:solidFill>
                      <a:schemeClr val="phClr" />
                    </a:solidFill>
                    <a:prstDash val="solid" />
                  </a:ln>
                  <a:ln w="38100" cap="flat" cmpd="sng" algn="ctr">
                    <a:solidFill>
                      <a:schemeClr val="phClr" />
                    </a:solidFill>
                    <a:prstDash val="solid" />
                  </a:ln>
                </a:lnStyleLst>
                <a:effectStyleLst>
                  <a:effectStyle>
                    <a:effectLst>
                      <a:outerShdw blurRad="40000" dist="20000" dir="5400000" rotWithShape="0">
                        <a:srgbClr val="000000">
                          <a:alpha val="38000" />
                        </a:srgbClr>
                      </a:outerShdw>
                    </a:effectLst>
                  </a:effectStyle>
                  <a:effectStyle>
                    <a:effectLst>
                      <a:outerShdw blurRad="40000" dist="23000" dir="5400000" rotWithShape="0">
                        <a:srgbClr val="000000">
                          <a:alpha val="35000" />
                        </a:srgbClr>
                      </a:outerShdw>
                    </a:effectLst>
                  </a:effectStyle>
                  <a:effectStyle>
                    <a:effectLst>
                      <a:outerShdw blurRad="40000" dist="23000" dir="5400000" rotWithShape="0">
                        <a:srgbClr val="000000">
                          <a:alpha val="35000" />
                        </a:srgbClr>
                      </a:outerShdw>
                    </a:effectLst>
                    <a:scene3d>
                      <a:camera prst="orthographicFront">
                        <a:rot lat="0" lon="0" rev="0" />
                      </a:camera>
                      <a:lightRig rig="threePt" dir="t">
                        <a:rot lat="0" lon="0" rev="1200000" />
                      </a:lightRig>
                    </a:scene3d>
                    <a:sp3d>
                      <a:bevelT w="63500" h="25400" />
                    </a:sp3d>
                  </a:effectStyle>
                </a:effectStyleLst>
                <a:bgFillStyleLst>
                  <a:solidFill>
                    <a:schemeClr val="phClr" />
                  </a:solidFill>
                  <a:gradFill rotWithShape="1">
                    <a:gsLst>
                      <a:gs pos="0">
                        <a:schemeClr val="phClr">
                          <a:tint val="40000" />
                          <a:satMod val="350000" />
                        </a:schemeClr>
                      </a:gs>
                      <a:gs pos="40000">
                        <a:schemeClr val="phClr">
                          <a:tint val="45000" />
                          <a:shade val="99000" />
                          <a:satMod val="350000" />
                        </a:schemeClr>
                      </a:gs>
                      <a:gs pos="100000">
                        <a:schemeClr val="phClr">
                          <a:shade val="20000" />
                          <a:satMod val="255000" />
                        </a:schemeClr>
                      </a:gs>
                    </a:gsLst>
                    <a:path path="circle">
                      <a:fillToRect l="50000" t="-80000" r="50000" b="180000" />
                    </a:path>
                  </a:gradFill>
                  <a:gradFill rotWithShape="1">
                    <a:gsLst>
                      <a:gs pos="0">
                        <a:schemeClr val="phClr">
                          <a:tint val="80000" />
                          <a:satMod val="300000" />
                        </a:schemeClr>
                      </a:gs>
                      <a:gs pos="100000">
                        <a:schemeClr val="phClr">
                          <a:shade val="30000" />
                          <a:satMod val="200000" />
                        </a:schemeClr>
                      </a:gs>
                    </a:gsLst>
                    <a:path path="circle">
                      <a:fillToRect l="50000" t="50000" r="50000" b="50000" />
                    </a:path>
                  </a:gradFill>
                </a:bgFillStyleLst>
              </a:fmtScheme>
            </a:themeElements>
            <a:objectDefaults />
            <a:extraClrSchemeLst />
          </a:theme>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/word/settings.xml" pkg:contentType="application/vnd.openxmlformats-officedocument.wordprocessingml.settings+xml">
        <pkg:xmlData>
          <w:settings xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:w10="urn:schemas-microsoft-com:office:word" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main" xmlns:sl="http://schemas.openxmlformats.org/schemaLibrary/2006/main">
            <w:zoom w:percent="100" />
            <w:proofState w:spelling="clean" />
            <w:defaultTabStop w:val="708" />
            <w:hyphenationZone w:val="425" />
            <w:characterSpacingControl w:val="doNotCompress" />
            <w:saveInvalidXml />
            <w:ignoreMixedContent />
            <w:compat />
            <w:rsids>
              <w:rsidRoot w:val="003F34EB" />
              <w:rsid w:val="00023EB7" />
              <w:rsid w:val="000F1032" />
              <w:rsid w:val="00172879" />
              <w:rsid w:val="001A59F6" />
              <w:rsid w:val="001D50AE" />
              <w:rsid w:val="00276AB3" />
              <w:rsid w:val="00277B28" />
              <w:rsid w:val="00344122" />
              <w:rsid w:val="00350F67" />
              <w:rsid w:val="003F34EB" />
              <w:rsid w:val="004322B0" />
              <w:rsid w:val="00447093" />
              <w:rsid w:val="004B569A" />
              <w:rsid w:val="004E2C82" />
              <w:rsid w:val="00507D84" />
              <w:rsid w:val="005356ED" />
              <w:rsid w:val="005A41AF" />
              <w:rsid w:val="00630B53" />
              <w:rsid w:val="0066207B" />
              <w:rsid w:val="00735FE9" />
              <w:rsid w:val="00766601" />
              <w:rsid w:val="007C1B23" />
              <w:rsid w:val="007F5BE8" />
              <w:rsid w:val="00843656" />
              <w:rsid w:val="0084458B" />
              <w:rsid w:val="008F2CE4" />
              <w:rsid w:val="0096462A" />
              <w:rsid w:val="00A154CF" />
              <w:rsid w:val="00B30C23" />
              <w:rsid w:val="00B6413D" />
              <w:rsid w:val="00BD1304" />
              <w:rsid w:val="00BE7CD7" />
              <w:rsid w:val="00BF2243" />
              <w:rsid w:val="00C44FCE" />
              <w:rsid w:val="00CD56CC" />
              <w:rsid w:val="00D37BC3" />
              <w:rsid w:val="00D9107B" />
              <w:rsid w:val="00DE54D0" />
              <w:rsid w:val="00E16D89" />
              <w:rsid w:val="00E90EB5" />
              <w:rsid w:val="00F04F46" />
              <w:rsid w:val="00F168E5" />
              <w:rsid w:val="00F535F0" />
              <w:rsid w:val="00FF5E8F" />
            </w:rsids>
            <m:mathPr>
              <m:mathFont m:val="Cambria Math" />
              <m:brkBin m:val="before" />
              <m:brkBinSub m:val="--" />
              <m:smallFrac m:val="off" />
              <m:dispDef />
              <m:lMargin m:val="0" />
              <m:rMargin m:val="0" />
              <m:defJc m:val="centerGroup" />
              <m:wrapIndent m:val="1440" />
              <m:intLim m:val="subSup" />
              <m:naryLim m:val="undOvr" />
            </m:mathPr>
            <w:attachedSchema w:val="http://tempuri.org/XMLSchemaReport.xsd" />
            <w:themeFontLang w:val="fr-FR" />
            <w:clrSchemeMapping w:bg1="light1" w:t1="dark1" w:bg2="light2" w:t2="dark2" w:accent1="accent1" w:accent2="accent2" w:accent3="accent3" w:accent4="accent4" w:accent5="accent5" w:accent6="accent6" w:hyperlink="hyperlink" w:followedHyperlink="followedHyperlink" />
            <w:shapeDefaults>
              <o:shapedefaults v:ext="edit" spidmax="2050" />
              <o:shapelayout v:ext="edit">
                <o:idmap v:ext="edit" data="1" />
              </o:shapelayout>
            </w:shapeDefaults>
            <w:decimalSymbol w:val="," />
            <w:listSeparator w:val=";" />
          </w:settings>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/customXml/itemProps2.xml" pkg:contentType="application/vnd.openxmlformats-officedocument.customXmlProperties+xml" pkg:padding="32">
        <pkg:xmlData pkg:originalXmlStandalone="no">
          <ds:datastoreItem ds:itemID="{EEE26757-95C2-4847-9C62-D91B11E467CD}" xmlns:ds="http://schemas.openxmlformats.org/officeDocument/2006/customXml">
            <ds:schemaRefs>
              <ds:schemaRef ds:uri="http://schemas.openxmlformats.org/officeDocument/2006/bibliography" />
            </ds:schemaRefs>
          </ds:datastoreItem>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/customXml/itemProps1.xml" pkg:contentType="application/vnd.openxmlformats-officedocument.customXmlProperties+xml" pkg:padding="32">
        <pkg:xmlData pkg:originalXmlStandalone="no">
          <ds:datastoreItem ds:itemID="{09D691B9-C1A6-4ED6-9C3D-64213AFEA96A}" xmlns:ds="http://schemas.openxmlformats.org/officeDocument/2006/customXml">
            <ds:schemaRefs>
              <ds:schemaRef ds:uri="http://schemas.microsoft.com/office/2006/customDocumentInformationPanel" />
            </ds:schemaRefs>
          </ds:datastoreItem>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/customXml/item2.xml" pkg:contentType="application/xml" pkg:padding="32">
        <pkg:xmlData>
          <b:Sources SelectedStyle="\APA.XSL" StyleName="APA" xmlns:b="http://schemas.openxmlformats.org/officeDocument/2006/bibliography" xmlns="http://schemas.openxmlformats.org/officeDocument/2006/bibliography" />
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/customXml/_rels/item2.xml.rels" pkg:contentType="application/vnd.openxmlformats-package.relationships+xml" pkg:padding="256">
        <pkg:xmlData>
          <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
            <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXmlProps" Target="itemProps2.xml" />
          </Relationships>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/customXml/_rels/item1.xml.rels" pkg:contentType="application/vnd.openxmlformats-package.relationships+xml" pkg:padding="256">
        <pkg:xmlData>
          <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
            <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXmlProps" Target="itemProps1.xml" />
          </Relationships>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/word/fontTable.xml" pkg:contentType="application/vnd.openxmlformats-officedocument.wordprocessingml.fontTable+xml">
        <pkg:xmlData>
          <w:fonts xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
            <w:font w:name="Calibri">
              <w:panose1 w:val="020F0502020204030204" />
              <w:charset w:val="00" />
              <w:family w:val="swiss" />
              <w:pitch w:val="variable" />
              <w:sig w:usb0="E10002FF" w:usb1="4000ACFF" w:usb2="00000009" w:usb3="00000000" w:csb0="0000019F" w:csb1="00000000" />
            </w:font>
            <w:font w:name="Times New Roman">
              <w:panose1 w:val="02020603050405020304" />
              <w:charset w:val="00" />
              <w:family w:val="roman" />
              <w:pitch w:val="variable" />
              <w:sig w:usb0="E0002AFF" w:usb1="C0007841" w:usb2="00000009" w:usb3="00000000" w:csb0="000001FF" w:csb1="00000000" />
            </w:font>
            <w:font w:name="Cambria">
              <w:panose1 w:val="02040503050406030204" />
              <w:charset w:val="00" />
              <w:family w:val="roman" />
              <w:pitch w:val="variable" />
              <w:sig w:usb0="A00002EF" w:usb1="4000004B" w:usb2="00000000" w:usb3="00000000" w:csb0="0000019F" w:csb1="00000000" />
            </w:font>
            <w:font w:name="Tahoma">
              <w:panose1 w:val="020B0604030504040204" />
              <w:charset w:val="00" />
              <w:family w:val="swiss" />
              <w:pitch w:val="variable" />
              <w:sig w:usb0="E1002EFF" w:usb1="C000605B" w:usb2="00000029" w:usb3="00000000" w:csb0="000101FF" w:csb1="00000000" />
            </w:font>
          </w:fonts>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/docProps/core.xml" pkg:contentType="application/vnd.openxmlformats-package.core-properties+xml" pkg:padding="256">
        <pkg:xmlData>
          <cp:coreProperties xmlns:cp="http://schemas.openxmlformats.org/package/2006/metadata/core-properties" xmlns:dc="http://purl.org/dc/elements/1.1/" xmlns:dcterms="http://purl.org/dc/terms/" xmlns:dcmitype="http://purl.org/dc/dcmitype/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
            <dc:creator>François</dc:creator>
            <cp:lastModifiedBy>François</cp:lastModifiedBy>
            <cp:revision>2</cp:revision>
            <dcterms:created xsi:type="dcterms:W3CDTF">2010-07-04T12:37:00Z</dcterms:created>
            <dcterms:modified xsi:type="dcterms:W3CDTF">2010-07-04T12:37:00Z</dcterms:modified>
          </cp:coreProperties>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/customXml/item1.xml" pkg:contentType="application/xml" pkg:padding="32">
        <pkg:xmlData>
          <tns:customPropertyEditors xmlns:tns="http://schemas.microsoft.com/office/2006/customDocumentInformationPanel">
            <tns:showOnOpen>false</tns:showOnOpen>
            <tns:defaultPropertyEditorNamespace>Standard properties</tns:defaultPropertyEditorNamespace>
          </tns:customPropertyEditors>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/word/webSettings.xml" pkg:contentType="application/vnd.openxmlformats-officedocument.wordprocessingml.webSettings+xml">
        <pkg:xmlData>
          <w:webSettings xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
            <w:optimizeForBrowser />
          </w:webSettings>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/word/styles.xml" pkg:contentType="application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml">
        <pkg:xmlData>
          <w:styles xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
            <w:docDefaults>
              <w:rPrDefault>
                <w:rPr>
                  <w:rFonts w:asciiTheme="minorHAnsi" w:eastAsiaTheme="minorHAnsi" w:hAnsiTheme="minorHAnsi" w:cstheme="minorBidi" />
                  <w:sz w:val="22" />
                  <w:szCs w:val="22" />
                  <w:lang w:val="fr-FR" w:eastAsia="en-US" w:bidi="ar-SA" />
                </w:rPr>
              </w:rPrDefault>
              <w:pPrDefault>
                <w:pPr>
                  <w:spacing w:after="200" w:line="276" w:lineRule="auto" />
                </w:pPr>
              </w:pPrDefault>
            </w:docDefaults>
            <w:latentStyles w:defLockedState="0" w:defUIPriority="99" w:defSemiHidden="1" w:defUnhideWhenUsed="1" w:defQFormat="0" w:count="267">
              <w:lsdException w:name="Normal" w:semiHidden="0" w:uiPriority="0" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="heading 1" w:semiHidden="0" w:uiPriority="9" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="heading 2" w:uiPriority="9" w:qFormat="1" />
              <w:lsdException w:name="heading 3" w:uiPriority="9" w:qFormat="1" />
              <w:lsdException w:name="heading 4" w:uiPriority="9" w:qFormat="1" />
              <w:lsdException w:name="heading 5" w:uiPriority="9" w:qFormat="1" />
              <w:lsdException w:name="heading 6" w:uiPriority="9" w:qFormat="1" />
              <w:lsdException w:name="heading 7" w:uiPriority="9" w:qFormat="1" />
              <w:lsdException w:name="heading 8" w:uiPriority="9" w:qFormat="1" />
              <w:lsdException w:name="heading 9" w:uiPriority="9" w:qFormat="1" />
              <w:lsdException w:name="toc 1" w:uiPriority="39" />
              <w:lsdException w:name="toc 2" w:uiPriority="39" />
              <w:lsdException w:name="toc 3" w:uiPriority="39" />
              <w:lsdException w:name="toc 4" w:uiPriority="39" />
              <w:lsdException w:name="toc 5" w:uiPriority="39" />
              <w:lsdException w:name="toc 6" w:uiPriority="39" />
              <w:lsdException w:name="toc 7" w:uiPriority="39" />
              <w:lsdException w:name="toc 8" w:uiPriority="39" />
              <w:lsdException w:name="toc 9" w:uiPriority="39" />
              <w:lsdException w:name="caption" w:uiPriority="35" w:qFormat="1" />
              <w:lsdException w:name="Title" w:semiHidden="0" w:uiPriority="10" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Default Paragraph Font" w:uiPriority="1" />
              <w:lsdException w:name="Subtitle" w:semiHidden="0" w:uiPriority="11" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Strong" w:semiHidden="0" w:uiPriority="22" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Emphasis" w:semiHidden="0" w:uiPriority="20" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Table Grid" w:semiHidden="0" w:uiPriority="59" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Placeholder Text" w:unhideWhenUsed="0" />
              <w:lsdException w:name="No Spacing" w:semiHidden="0" w:uiPriority="1" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Light Shading" w:semiHidden="0" w:uiPriority="60" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light List" w:semiHidden="0" w:uiPriority="61" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Grid" w:semiHidden="0" w:uiPriority="62" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 1" w:semiHidden="0" w:uiPriority="63" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 2" w:semiHidden="0" w:uiPriority="64" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 1" w:semiHidden="0" w:uiPriority="65" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 2" w:semiHidden="0" w:uiPriority="66" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 1" w:semiHidden="0" w:uiPriority="67" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 2" w:semiHidden="0" w:uiPriority="68" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 3" w:semiHidden="0" w:uiPriority="69" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Dark List" w:semiHidden="0" w:uiPriority="70" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Shading" w:semiHidden="0" w:uiPriority="71" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful List" w:semiHidden="0" w:uiPriority="72" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Grid" w:semiHidden="0" w:uiPriority="73" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Shading Accent 1" w:semiHidden="0" w:uiPriority="60" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light List Accent 1" w:semiHidden="0" w:uiPriority="61" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Grid Accent 1" w:semiHidden="0" w:uiPriority="62" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 1 Accent 1" w:semiHidden="0" w:uiPriority="63" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 2 Accent 1" w:semiHidden="0" w:uiPriority="64" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 1 Accent 1" w:semiHidden="0" w:uiPriority="65" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Revision" w:unhideWhenUsed="0" />
              <w:lsdException w:name="List Paragraph" w:semiHidden="0" w:uiPriority="34" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Quote" w:semiHidden="0" w:uiPriority="29" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Intense Quote" w:semiHidden="0" w:uiPriority="30" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Medium List 2 Accent 1" w:semiHidden="0" w:uiPriority="66" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 1 Accent 1" w:semiHidden="0" w:uiPriority="67" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 2 Accent 1" w:semiHidden="0" w:uiPriority="68" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 3 Accent 1" w:semiHidden="0" w:uiPriority="69" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Dark List Accent 1" w:semiHidden="0" w:uiPriority="70" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Shading Accent 1" w:semiHidden="0" w:uiPriority="71" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful List Accent 1" w:semiHidden="0" w:uiPriority="72" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Grid Accent 1" w:semiHidden="0" w:uiPriority="73" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Shading Accent 2" w:semiHidden="0" w:uiPriority="60" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light List Accent 2" w:semiHidden="0" w:uiPriority="61" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Grid Accent 2" w:semiHidden="0" w:uiPriority="62" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 1 Accent 2" w:semiHidden="0" w:uiPriority="63" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 2 Accent 2" w:semiHidden="0" w:uiPriority="64" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 1 Accent 2" w:semiHidden="0" w:uiPriority="65" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 2 Accent 2" w:semiHidden="0" w:uiPriority="66" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 1 Accent 2" w:semiHidden="0" w:uiPriority="67" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 2 Accent 2" w:semiHidden="0" w:uiPriority="68" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 3 Accent 2" w:semiHidden="0" w:uiPriority="69" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Dark List Accent 2" w:semiHidden="0" w:uiPriority="70" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Shading Accent 2" w:semiHidden="0" w:uiPriority="71" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful List Accent 2" w:semiHidden="0" w:uiPriority="72" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Grid Accent 2" w:semiHidden="0" w:uiPriority="73" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Shading Accent 3" w:semiHidden="0" w:uiPriority="60" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light List Accent 3" w:semiHidden="0" w:uiPriority="61" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Grid Accent 3" w:semiHidden="0" w:uiPriority="62" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 1 Accent 3" w:semiHidden="0" w:uiPriority="63" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 2 Accent 3" w:semiHidden="0" w:uiPriority="64" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 1 Accent 3" w:semiHidden="0" w:uiPriority="65" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 2 Accent 3" w:semiHidden="0" w:uiPriority="66" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 1 Accent 3" w:semiHidden="0" w:uiPriority="67" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 2 Accent 3" w:semiHidden="0" w:uiPriority="68" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 3 Accent 3" w:semiHidden="0" w:uiPriority="69" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Dark List Accent 3" w:semiHidden="0" w:uiPriority="70" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Shading Accent 3" w:semiHidden="0" w:uiPriority="71" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful List Accent 3" w:semiHidden="0" w:uiPriority="72" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Grid Accent 3" w:semiHidden="0" w:uiPriority="73" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Shading Accent 4" w:semiHidden="0" w:uiPriority="60" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light List Accent 4" w:semiHidden="0" w:uiPriority="61" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Grid Accent 4" w:semiHidden="0" w:uiPriority="62" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 1 Accent 4" w:semiHidden="0" w:uiPriority="63" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 2 Accent 4" w:semiHidden="0" w:uiPriority="64" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 1 Accent 4" w:semiHidden="0" w:uiPriority="65" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 2 Accent 4" w:semiHidden="0" w:uiPriority="66" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 1 Accent 4" w:semiHidden="0" w:uiPriority="67" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 2 Accent 4" w:semiHidden="0" w:uiPriority="68" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 3 Accent 4" w:semiHidden="0" w:uiPriority="69" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Dark List Accent 4" w:semiHidden="0" w:uiPriority="70" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Shading Accent 4" w:semiHidden="0" w:uiPriority="71" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful List Accent 4" w:semiHidden="0" w:uiPriority="72" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Grid Accent 4" w:semiHidden="0" w:uiPriority="73" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Shading Accent 5" w:semiHidden="0" w:uiPriority="60" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light List Accent 5" w:semiHidden="0" w:uiPriority="61" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Grid Accent 5" w:semiHidden="0" w:uiPriority="62" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 1 Accent 5" w:semiHidden="0" w:uiPriority="63" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 2 Accent 5" w:semiHidden="0" w:uiPriority="64" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 1 Accent 5" w:semiHidden="0" w:uiPriority="65" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 2 Accent 5" w:semiHidden="0" w:uiPriority="66" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 1 Accent 5" w:semiHidden="0" w:uiPriority="67" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 2 Accent 5" w:semiHidden="0" w:uiPriority="68" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 3 Accent 5" w:semiHidden="0" w:uiPriority="69" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Dark List Accent 5" w:semiHidden="0" w:uiPriority="70" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Shading Accent 5" w:semiHidden="0" w:uiPriority="71" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful List Accent 5" w:semiHidden="0" w:uiPriority="72" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Grid Accent 5" w:semiHidden="0" w:uiPriority="73" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Shading Accent 6" w:semiHidden="0" w:uiPriority="60" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light List Accent 6" w:semiHidden="0" w:uiPriority="61" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Light Grid Accent 6" w:semiHidden="0" w:uiPriority="62" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 1 Accent 6" w:semiHidden="0" w:uiPriority="63" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Shading 2 Accent 6" w:semiHidden="0" w:uiPriority="64" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 1 Accent 6" w:semiHidden="0" w:uiPriority="65" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium List 2 Accent 6" w:semiHidden="0" w:uiPriority="66" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 1 Accent 6" w:semiHidden="0" w:uiPriority="67" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 2 Accent 6" w:semiHidden="0" w:uiPriority="68" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Medium Grid 3 Accent 6" w:semiHidden="0" w:uiPriority="69" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Dark List Accent 6" w:semiHidden="0" w:uiPriority="70" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Shading Accent 6" w:semiHidden="0" w:uiPriority="71" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful List Accent 6" w:semiHidden="0" w:uiPriority="72" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Colorful Grid Accent 6" w:semiHidden="0" w:uiPriority="73" w:unhideWhenUsed="0" />
              <w:lsdException w:name="Subtle Emphasis" w:semiHidden="0" w:uiPriority="19" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Intense Emphasis" w:semiHidden="0" w:uiPriority="21" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Subtle Reference" w:semiHidden="0" w:uiPriority="31" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Intense Reference" w:semiHidden="0" w:uiPriority="32" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Book Title" w:semiHidden="0" w:uiPriority="33" w:unhideWhenUsed="0" w:qFormat="1" />
              <w:lsdException w:name="Bibliography" w:uiPriority="37" />
              <w:lsdException w:name="TOC Heading" w:uiPriority="39" w:qFormat="1" />
            </w:latentStyles>
            <w:style w:type="paragraph" w:default="1" w:styleId="Normal">
              <w:name w:val="Normal" />
              <w:qFormat />
              <w:rsid w:val="00B30C23" />
              <w:rPr>
                <w:lang w:val="en-US" />
              </w:rPr>
            </w:style>
            <w:style w:type="paragraph" w:styleId="Heading1">
              <w:name w:val="heading 1" />
              <w:basedOn w:val="Normal" />
              <w:next w:val="Normal" />
              <w:link w:val="Heading1Char" />
              <w:uiPriority w:val="9" />
              <w:qFormat />
              <w:rsid w:val="0066207B" />
              <w:pPr>
                <w:keepNext />
                <w:keepLines />
                <w:spacing w:before="480" w:after="0" />
                <w:outlineLvl w:val="0" />
              </w:pPr>
              <w:rPr>
                <w:rFonts w:asciiTheme="majorHAnsi" w:eastAsiaTheme="majorEastAsia" w:hAnsiTheme="majorHAnsi" w:cstheme="majorBidi" />
                <w:b />
                <w:bCs />
                <w:color w:val="365F91" w:themeColor="accent1" w:themeShade="BF" />
                <w:sz w:val="28" />
                <w:szCs w:val="28" />
              </w:rPr>
            </w:style>
            <w:style w:type="paragraph" w:styleId="Heading2">
              <w:name w:val="heading 2" />
              <w:basedOn w:val="Normal" />
              <w:next w:val="Normal" />
              <w:link w:val="Heading2Char" />
              <w:uiPriority w:val="9" />
              <w:unhideWhenUsed />
              <w:qFormat />
              <w:rsid w:val="0066207B" />
              <w:pPr>
                <w:keepNext />
                <w:keepLines />
                <w:spacing w:before="200" w:after="0" />
                <w:outlineLvl w:val="1" />
              </w:pPr>
              <w:rPr>
                <w:rFonts w:asciiTheme="majorHAnsi" w:eastAsiaTheme="majorEastAsia" w:hAnsiTheme="majorHAnsi" w:cstheme="majorBidi" />
                <w:b />
                <w:bCs />
                <w:color w:val="4F81BD" w:themeColor="accent1" />
                <w:sz w:val="26" />
                <w:szCs w:val="26" />
              </w:rPr>
            </w:style>
            <w:style w:type="character" w:default="1" w:styleId="DefaultParagraphFont">
              <w:name w:val="Default Paragraph Font" />
              <w:uiPriority w:val="1" />
              <w:semiHidden />
              <w:unhideWhenUsed />
            </w:style>
            <w:style w:type="table" w:default="1" w:styleId="TableNormal">
              <w:name w:val="Normal Table" />
              <w:uiPriority w:val="99" />
              <w:semiHidden />
              <w:unhideWhenUsed />
              <w:qFormat />
              <w:tblPr>
                <w:tblInd w:w="0" w:type="dxa" />
                <w:tblCellMar>
                  <w:top w:w="0" w:type="dxa" />
                  <w:left w:w="108" w:type="dxa" />
                  <w:bottom w:w="0" w:type="dxa" />
                  <w:right w:w="108" w:type="dxa" />
                </w:tblCellMar>
              </w:tblPr>
            </w:style>
            <w:style w:type="numbering" w:default="1" w:styleId="NoList">
              <w:name w:val="No List" />
              <w:uiPriority w:val="99" />
              <w:semiHidden />
              <w:unhideWhenUsed />
            </w:style>
            <w:style w:type="table" w:styleId="TableGrid">
              <w:name w:val="Table Grid" />
              <w:basedOn w:val="TableNormal" />
              <w:uiPriority w:val="59" />
              <w:rsid w:val="003F34EB" />
              <w:pPr>
                <w:spacing w:after="0" w:line="240" w:lineRule="auto" />
              </w:pPr>
              <w:tblPr>
                <w:tblInd w:w="0" w:type="dxa" />
                <w:tblBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="000000" w:themeColor="text1" />
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="000000" w:themeColor="text1" />
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="000000" w:themeColor="text1" />
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="000000" w:themeColor="text1" />
                  <w:insideH w:val="single" w:sz="4" w:space="0" w:color="000000" w:themeColor="text1" />
                  <w:insideV w:val="single" w:sz="4" w:space="0" w:color="000000" w:themeColor="text1" />
                </w:tblBorders>
                <w:tblCellMar>
                  <w:top w:w="0" w:type="dxa" />
                  <w:left w:w="108" w:type="dxa" />
                  <w:bottom w:w="0" w:type="dxa" />
                  <w:right w:w="108" w:type="dxa" />
                </w:tblCellMar>
              </w:tblPr>
            </w:style>
            <w:style w:type="character" w:customStyle="1" w:styleId="Heading1Char">
              <w:name w:val="Heading 1 Char" />
              <w:basedOn w:val="DefaultParagraphFont" />
              <w:link w:val="Heading1" />
              <w:uiPriority w:val="9" />
              <w:rsid w:val="0066207B" />
              <w:rPr>
                <w:rFonts w:asciiTheme="majorHAnsi" w:eastAsiaTheme="majorEastAsia" w:hAnsiTheme="majorHAnsi" w:cstheme="majorBidi" />
                <w:b />
                <w:bCs />
                <w:color w:val="365F91" w:themeColor="accent1" w:themeShade="BF" />
                <w:sz w:val="28" />
                <w:szCs w:val="28" />
                <w:lang w:val="en-US" />
              </w:rPr>
            </w:style>
            <w:style w:type="character" w:customStyle="1" w:styleId="Heading2Char">
              <w:name w:val="Heading 2 Char" />
              <w:basedOn w:val="DefaultParagraphFont" />
              <w:link w:val="Heading2" />
              <w:uiPriority w:val="9" />
              <w:rsid w:val="0066207B" />
              <w:rPr>
                <w:rFonts w:asciiTheme="majorHAnsi" w:eastAsiaTheme="majorEastAsia" w:hAnsiTheme="majorHAnsi" w:cstheme="majorBidi" />
                <w:b />
                <w:bCs />
                <w:color w:val="4F81BD" w:themeColor="accent1" />
                <w:sz w:val="26" />
                <w:szCs w:val="26" />
                <w:lang w:val="en-US" />
              </w:rPr>
            </w:style>
            <w:style w:type="paragraph" w:styleId="Revision">
              <w:name w:val="Revision" />
              <w:hidden />
              <w:uiPriority w:val="99" />
              <w:semiHidden />
              <w:rsid w:val="00630B53" />
              <w:pPr>
                <w:spacing w:after="0" w:line="240" w:lineRule="auto" />
              </w:pPr>
              <w:rPr>
                <w:lang w:val="en-US" />
              </w:rPr>
            </w:style>
            <w:style w:type="paragraph" w:styleId="BalloonText">
              <w:name w:val="Balloon Text" />
              <w:basedOn w:val="Normal" />
              <w:link w:val="BalloonTextChar" />
              <w:uiPriority w:val="99" />
              <w:semiHidden />
              <w:unhideWhenUsed />
              <w:rsid w:val="00630B53" />
              <w:pPr>
                <w:spacing w:after="0" w:line="240" w:lineRule="auto" />
              </w:pPr>
              <w:rPr>
                <w:rFonts w:ascii="Tahoma" w:hAnsi="Tahoma" w:cs="Tahoma" />
                <w:sz w:val="16" />
                <w:szCs w:val="16" />
              </w:rPr>
            </w:style>
            <w:style w:type="character" w:customStyle="1" w:styleId="BalloonTextChar">
              <w:name w:val="Balloon Text Char" />
              <w:basedOn w:val="DefaultParagraphFont" />
              <w:link w:val="BalloonText" />
              <w:uiPriority w:val="99" />
              <w:semiHidden />
              <w:rsid w:val="00630B53" />
              <w:rPr>
                <w:rFonts w:ascii="Tahoma" w:hAnsi="Tahoma" w:cs="Tahoma" />
                <w:sz w:val="16" />
                <w:szCs w:val="16" />
                <w:lang w:val="en-US" />
              </w:rPr>
            </w:style>
          </w:styles>
        </pkg:xmlData>
      </pkg:part>
      <pkg:part pkg:name="/docProps/app.xml" pkg:contentType="application/vnd.openxmlformats-officedocument.extended-properties+xml" pkg:padding="256">
        <pkg:xmlData>
          <Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/extended-properties" xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
            <Template>Normal.dotm</Template>
            <TotalTime>33</TotalTime>
            <Pages>4</Pages>
            <Words>238</Words>
            <Characters>1315</Characters>
            <Application>Microsoft Office Word</Application>
            <DocSecurity>0</DocSecurity>
            <Lines>10</Lines>
            <Paragraphs>3</Paragraphs>
            <ScaleCrop>false</ScaleCrop>
            <HeadingPairs>
              <vt:vector size="2" baseType="variant">
                <vt:variant>
                  <vt:lpstr>Title</vt:lpstr>
                </vt:variant>
                <vt:variant>
                  <vt:i4>1</vt:i4>
                </vt:variant>
              </vt:vector>
            </HeadingPairs>
            <TitlesOfParts>
              <vt:vector size="1" baseType="lpstr">
                <vt:lpstr />
              </vt:vector>
            </TitlesOfParts>
            <Company>Microsoft</Company>
            <LinksUpToDate>false</LinksUpToDate>
            <CharactersWithSpaces>1550</CharactersWithSpaces>
            <SharedDoc>false</SharedDoc>
            <HyperlinksChanged>false</HyperlinksChanged>
            <AppVersion>12.0000</AppVersion>
          </Properties>
        </pkg:xmlData>
      </pkg:part>
    </pkg:package>
  </xsl:template>
  <xsl:template match="/w:document">
    <w:document xmlns:ve="http://schemas.openxmlformats.org/markup-compatibility/2006" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing" xmlns:w10="urn:schemas-microsoft-com:office:word" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main" xmlns:wne="http://schemas.microsoft.com/office/word/2006/wordml">
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:body" />
    </w:document>
  </xsl:template>
  <xsl:template match="/w:document/w:body">
    <w:body>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:sectPr|w:customXml" />
    </w:body>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tbl|w:p|w:customXml" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:p[1]">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:p[1]/w:pPr">
    <w:pPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:jc|w:rPr" />
    </w:pPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:p[1]/w:pPr/w:jc">
    <w:jc>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:jc>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:p[1]/w:r[3]/w:rPr">
    <w:rPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:lang|w:szCs|w:b|w:sz" />
    </w:rPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:p[5]">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl">
    <w:tbl>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tr|w:tblPr|w:tblGrid" />
    </w:tbl>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]">
    <w:tr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tc" />
    </w:tr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl/w:tblGrid">
    <w:tblGrid>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:gridCol" />
    </w:tblGrid>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tbl|w:p|w:customXml" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:p[1]">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl">
    <w:tbl>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tr|w:tblPr|w:tblGrid" />
    </w:tbl>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r/w:drawing">
    <w:drawing>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <wp:inline distT="0" distB="0" distL="0" distR="0">
        <wp:extent cx="2438400" cy="2438400" />
        <wp:effectExtent l="19050" t="0" r="0" b="0" />
        <wp:docPr id="2" name="Picture 2" descr="K:\Codeplex\StackBuilder\Samples\Case.bmp" />
        <wp:cNvGraphicFramePr>
          <a:graphicFrameLocks noChangeAspect="1" xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" />
        </wp:cNvGraphicFramePr>
        <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
          <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
            <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
              <pic:nvPicPr>
                <pic:cNvPr id="0" name="Picture 2" descr="K:\Codeplex\StackBuilder\Samples\Case.bmp" />
                <pic:cNvPicPr>
                  <a:picLocks noChangeAspect="1" noChangeArrowheads="1" />
                </pic:cNvPicPr>
              </pic:nvPicPr>
              <pic:blipFill>
                <a:blip r:embed="rId6" cstate="print" />
                <a:srcRect />
                <a:stretch>
                  <a:fillRect />
                </a:stretch>
              </pic:blipFill>
              <pic:spPr bwMode="auto">
                <a:xfrm>
                  <a:off x="0" y="0" />
                  <a:ext cx="2438400" cy="2438400" />
                </a:xfrm>
                <a:prstGeom prst="rect">
                  <a:avLst />
                </a:prstGeom>
                <a:noFill />
                <a:ln w="9525">
                  <a:noFill />
                  <a:miter lim="800000" />
                  <a:headEnd />
                  <a:tailEnd />
                </a:ln>
              </pic:spPr>
            </pic:pic>
          </a:graphicData>
        </a:graphic>
      </wp:inline>
      <w:p xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:r>
          <w:t>
            <xsl:value-of select="." />
          </w:t>
        </w:r>
      </w:p>
    </w:drawing>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl">
    <w:tbl>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tr|w:tblPr|w:tblGrid" />
    </w:tbl>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[1]">
    <w:r>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:drawing|w:rPr|w:lastRenderedPageBreak" />
    </w:r>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[1]/w:drawing">
    <w:drawing>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <wp:inline distT="0" distB="0" distL="0" distR="0">
        <wp:extent cx="2438400" cy="2438400" />
        <wp:effectExtent l="19050" t="0" r="0" b="0" />
        <wp:docPr id="5" name="Picture 4" descr="K:\Codeplex\StackBuilder\Samples\Pallet.bmp" />
        <wp:cNvGraphicFramePr>
          <a:graphicFrameLocks noChangeAspect="1" xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" />
        </wp:cNvGraphicFramePr>
        <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
          <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
            <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
              <pic:nvPicPr>
                <pic:cNvPr id="0" name="Picture 4" descr="K:\Codeplex\StackBuilder\Samples\Pallet.bmp" />
                <pic:cNvPicPr>
                  <a:picLocks noChangeAspect="1" noChangeArrowheads="1" />
                </pic:cNvPicPr>
              </pic:nvPicPr>
              <pic:blipFill>
                <a:blip r:embed="rId7" cstate="print" />
                <a:srcRect />
                <a:stretch>
                  <a:fillRect />
                </a:stretch>
              </pic:blipFill>
              <pic:spPr bwMode="auto">
                <a:xfrm>
                  <a:off x="0" y="0" />
                  <a:ext cx="2438400" cy="2438400" />
                </a:xfrm>
                <a:prstGeom prst="rect">
                  <a:avLst />
                </a:prstGeom>
                <a:noFill />
                <a:ln w="9525">
                  <a:noFill />
                  <a:miter lim="800000" />
                  <a:headEnd />
                  <a:tailEnd />
                </a:ln>
              </pic:spPr>
            </pic:pic>
          </a:graphicData>
        </a:graphic>
      </wp:inline>
      <w:p xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:r>
          <w:t>
            <xsl:value-of select="." />
          </w:t>
        </w:r>
      </w:p>
    </w:drawing>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:customXml|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl">
    <w:tbl>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tr|w:tblPr|w:tblGrid" />
    </w:tbl>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:p/w:r/w:drawing">
    <w:drawing>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <wp:inline distT="0" distB="0" distL="0" distR="0">
        <wp:extent cx="2438400" cy="2438400" />
        <wp:effectExtent l="19050" t="0" r="0" b="0" />
        <wp:docPr id="7" name="Picture 5" descr="K:\Codeplex\StackBuilder\Samples\Interlayer.bmp" />
        <wp:cNvGraphicFramePr>
          <a:graphicFrameLocks noChangeAspect="1" xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" />
        </wp:cNvGraphicFramePr>
        <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
          <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
            <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
              <pic:nvPicPr>
                <pic:cNvPr id="0" name="Picture 5" descr="K:\Codeplex\StackBuilder\Samples\Interlayer.bmp" />
                <pic:cNvPicPr>
                  <a:picLocks noChangeAspect="1" noChangeArrowheads="1" />
                </pic:cNvPicPr>
              </pic:nvPicPr>
              <pic:blipFill>
                <a:blip r:embed="rId8" cstate="print" />
                <a:srcRect />
                <a:stretch>
                  <a:fillRect />
                </a:stretch>
              </pic:blipFill>
              <pic:spPr bwMode="auto">
                <a:xfrm>
                  <a:off x="0" y="0" />
                  <a:ext cx="2438400" cy="2438400" />
                </a:xfrm>
                <a:prstGeom prst="rect">
                  <a:avLst />
                </a:prstGeom>
                <a:noFill />
                <a:ln w="9525">
                  <a:noFill />
                  <a:miter lim="800000" />
                  <a:headEnd />
                  <a:tailEnd />
                </a:ln>
              </pic:spPr>
            </pic:pic>
          </a:graphicData>
        </a:graphic>
      </wp:inline>
      <w:p xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:r>
          <w:t>
            <xsl:value-of select="." />
          </w:t>
        </w:r>
      </w:p>
    </w:drawing>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl">
    <w:tbl>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tr|w:tblPr|w:tblGrid" />
    </w:tbl>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:customXml|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl">
    <w:tbl>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tr|w:tblPr|w:customXml|w:tblGrid" />
    </w:tbl>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tblPr">
    <w:tblPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tblW|w:tblLook|w:tblStyle" />
    </w:tblPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tr" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr">
    <w:tr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:trPr|w:tc" />
    </w:tr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:trPr">
    <w:trPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:trHeight" />
    </w:trPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:trPr/w:trHeight">
    <w:trHeight>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:trHeight>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc">
    <w:tc>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:p|w:tcPr" />
    </w:tc>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:tcPr">
    <w:tcPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:gridSpan|w:tcBorders|w:tcW" />
    </w:tcPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[1]/w:r/w:drawing">
    <w:drawing>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <wp:inline distT="0" distB="0" distL="0" distR="0">
        <wp:extent cx="4876800" cy="4876800" />
        <wp:effectExtent l="19050" t="0" r="0" b="0" />
        <wp:docPr id="1" name="Picture 1" descr="K:\Codeplex\StackBuilder\Samples\Solution.bmp" />
        <wp:cNvGraphicFramePr>
          <a:graphicFrameLocks noChangeAspect="1" xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" />
        </wp:cNvGraphicFramePr>
        <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
          <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
            <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
              <pic:nvPicPr>
                <pic:cNvPr id="0" name="Picture 1" descr="K:\Codeplex\StackBuilder\Samples\Solution.bmp" />
                <pic:cNvPicPr>
                  <a:picLocks noChangeAspect="1" noChangeArrowheads="1" />
                </pic:cNvPicPr>
              </pic:nvPicPr>
              <pic:blipFill>
                <a:blip r:embed="rId9" cstate="print" />
                <a:srcRect />
                <a:stretch>
                  <a:fillRect />
                </a:stretch>
              </pic:blipFill>
              <pic:spPr bwMode="auto">
                <a:xfrm>
                  <a:off x="0" y="0" />
                  <a:ext cx="4876800" cy="4876800" />
                </a:xfrm>
                <a:prstGeom prst="rect">
                  <a:avLst />
                </a:prstGeom>
                <a:noFill />
                <a:ln w="9525">
                  <a:noFill />
                  <a:miter lim="800000" />
                  <a:headEnd />
                  <a:tailEnd />
                </a:ln>
              </pic:spPr>
            </pic:pic>
          </a:graphicData>
        </a:graphic>
      </wp:inline>
      <w:p xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:r>
          <w:t>
            <xsl:value-of select="." />
          </w:t>
        </w:r>
      </w:p>
    </w:drawing>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:tbl">
    <w:tbl>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tr|w:tblPr|w:tblGrid" />
    </w:tbl>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:customXml|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:sectPr">
    <w:sectPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:cols|w:docGrid|w:pgMar|w:pgSz" />
    </w:sectPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:sectPr/w:cols">
    <w:cols>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:cols>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:sectPr/w:pgSz">
    <w:pgSz>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:pgSz>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:sectPr/w:docGrid">
    <w:docGrid>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:docGrid>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:sectPr/w:pgMar">
    <w:pgMar>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:pgMar>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:left|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcBorders/w:left">
    <w:left>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:left>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:gridSpan">
    <w:gridSpan>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:gridSpan>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:insideV|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblBorders/w:insideV|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:insideV|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblBorders/w:insideV|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblBorders/w:insideV|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblBorders/w:insideV">
    <w:insideV>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:insideV>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:pPr/w:pStyle|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:p/w:pPr/w:pStyle|/w:document/w:body/w:customXml/w:p[7]/w:pPr/w:pStyle|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p/w:pPr/w:pStyle|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:pPr/w:pStyle|/w:document/w:body/w:customXml/w:p[5]/w:pPr/w:pStyle|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p/w:pPr/w:pStyle|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:pPr/w:pStyle|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:pPr/w:pStyle">
    <w:pStyle>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:pStyle>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:p[1]/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:p[5]/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r">
    <w:r>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:rPr|w:t" />
    </w:r>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]|/w:document/w:body/w:customXml/w:p[7]/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[1]">
    <w:r>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:rPr|w:lastRenderedPageBreak|w:t" />
    </w:r>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:p/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[1]/w:r|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r">
    <w:r>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:drawing|w:rPr" />
    </w:r>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblBorders|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblBorders|/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblBorders">
    <w:tblBorders>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:insideV|w:insideH|w:right|w:top|w:bottom|w:left" />
    </w:tblBorders>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblBorders/w:insideH|/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:insideH|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:insideH|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblBorders/w:insideH|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblBorders/w:insideH|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblBorders/w:insideH">
    <w:insideH>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:insideH>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcBorders|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders">
    <w:tcBorders>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:right|w:top|w:bottom|w:left" />
    </w:tcBorders>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tbl|w:p" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:p" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml">
    <w:customXml>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr" />
    </w:customXml>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[1]/w:rPr/w:noProof|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:p/w:r/w:rPr/w:noProof|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[1]/w:r/w:rPr/w:noProof|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r/w:rPr/w:noProof">
    <w:noProof>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:noProof>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[4]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[3]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r[position() &gt;= 3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[1]/w:r[4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[5]/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[position() &gt;= 4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[5]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r[position() &gt;= 3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[6]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[position() &gt;= 7]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[2]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[position() &gt;= 2]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[1]/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[8]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[5]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[1]/w:r[5]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[7]/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[2]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[1]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[1]/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[7]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[3]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[6]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[5]/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r[position() &gt;= 3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[1]/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[position() &gt;= 3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r[position() &gt;= 3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[1]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[1]/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[1]/w:r[position() &gt;= 6]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 5]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:p[4]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[4]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r/w:rPr/w:lang|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[3]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[2]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:r[1]/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:lang">
    <w:lang>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:lang>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcBorders/w:bottom|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblBorders/w:bottom">
    <w:bottom>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:bottom>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:right|/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:right|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcBorders/w:right">
    <w:right>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:right>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[position() &gt;= 3]/w:tcPr/w:tcW">
    <w:tcW>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:tcW>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[4]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[3]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[3]/w:rPr/w:b|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[3]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[3]/w:rPr/w:b|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[4]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[3]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:p[1]/w:r[3]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[4]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[4]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[3]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[3]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[2]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr/w:b|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr/w:b">
    <w:b>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:b>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:pPr|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:p[5]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[position() &gt;= 2]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:p[8]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:p[6]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:p[2]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:p[position() &gt;= 7]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:p[4]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:p[3]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:p[2]/w:pPr|/w:document/w:body/w:customXml/w:p[3]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:p[4]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[1]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:p[6]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:p/w:pPr">
    <w:pPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:rPr" />
    </w:pPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p/w:pPr|/w:document/w:body/w:customXml/w:p[5]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p/w:pPr|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:pPr|/w:document/w:body/w:customXml/w:p[7]/w:pPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:p/w:pPr">
    <w:pPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:rPr|w:pStyle" />
    </w:pPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr/w:vMerge">
    <w:vMerge>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:vMerge>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:p[1]/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:p[5]/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:proofErr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:proofErr">
    <w:proofErr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:proofErr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblGrid|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblGrid|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblGrid|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblGrid">
    <w:tblGrid>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:gridCol" />
    </w:tblGrid>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tblGrid|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblGrid">
    <w:tblGrid>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:gridCol" />
    </w:tblGrid>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:p[1]/w:r[5]/w:rPr/w:szCs|/w:document/w:body/w:customXml/w:p[1]/w:r[position() &gt;= 6]/w:rPr/w:szCs|/w:document/w:body/w:customXml/w:p[1]/w:r[2]/w:rPr/w:szCs|/w:document/w:body/w:customXml/w:p[1]/w:r[3]/w:rPr/w:szCs|/w:document/w:body/w:customXml/w:p[1]/w:r[4]/w:rPr/w:szCs|/w:document/w:body/w:customXml/w:p[1]/w:pPr/w:rPr/w:szCs|/w:document/w:body/w:customXml/w:p[1]/w:r[1]/w:rPr/w:szCs">
    <w:szCs>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:szCs>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:lastRenderedPageBreak|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:lastRenderedPageBreak|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[1]/w:lastRenderedPageBreak|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[1]/w:lastRenderedPageBreak|/w:document/w:body/w:customXml/w:p[7]/w:r/w:lastRenderedPageBreak">
    <w:lastRenderedPageBreak>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:lastRenderedPageBreak>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:tcPr/w:tcBorders/w:top|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblBorders/w:top">
    <w:top>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:top>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblStyle|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tblPr/w:tblStyle|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblStyle|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblStyle|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblStyle|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblStyle|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblStyle">
    <w:tblStyle>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:tblStyle>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[2]/w:tcPr">
    <w:tcPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tcW" />
    </w:tcPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr">
    <w:tcPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:gridSpan|w:tcW" />
    </w:tcPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[position() &gt;= 3]/w:tcPr">
    <w:tcPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tcW|w:vMerge" />
    </w:tcPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:tcPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:tcPr">
    <w:tcPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tcBorders|w:tcW" />
    </w:tcPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblLook|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblLook|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblLook|/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblLook|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblLook|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblLook|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tblPr/w:tblLook">
    <w:tblLook>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:tblLook>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblGrid/w:gridCol|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tblGrid/w:gridCol|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblGrid/w:gridCol|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblGrid/w:gridCol|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblGrid/w:gridCol|/w:document/w:body/w:customXml/w:tbl/w:tblGrid/w:gridCol|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblGrid/w:gridCol">
    <w:gridCol>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:gridCol>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:p[2]|/w:document/w:body/w:customXml/w:p[3]|/w:document/w:body/w:customXml/w:p[4]|/w:document/w:body/w:customXml/w:p[6]|/w:document/w:body/w:customXml/w:p[8]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:p[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[position() &gt;= 3]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:p[7]|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:customXml|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml/w:p|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p">
    <w:p>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:r|w:proofErr|w:pPr" />
    </w:p>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:p[1]/w:r[3]/w:rPr/w:sz|/w:document/w:body/w:customXml/w:p[1]/w:r[4]/w:rPr/w:sz|/w:document/w:body/w:customXml/w:p[1]/w:r[5]/w:rPr/w:sz|/w:document/w:body/w:customXml/w:p[1]/w:pPr/w:rPr/w:sz|/w:document/w:body/w:customXml/w:p[1]/w:r[position() &gt;= 6]/w:rPr/w:sz|/w:document/w:body/w:customXml/w:p[1]/w:r[1]/w:rPr/w:sz|/w:document/w:body/w:customXml/w:p[1]/w:r[2]/w:rPr/w:sz">
    <w:sz>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:sz>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc">
    <w:tc>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:p|w:tcPr" />
    </w:tc>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]">
    <w:tc>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:customXml|w:tcPr" />
    </w:tc>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]|/w:document/w:body/w:customXml/w:tbl/w:tr[1]|/w:document/w:body/w:customXml/w:tbl/w:tr[2]|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr">
    <w:tr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tc" />
    </w:tr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 5]|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 3]|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 3]|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 3]">
    <w:tr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tc" />
    </w:tr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:p[1]/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:p[1]/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:p[1]/w:r[4]/w:rPr|/w:document/w:body/w:customXml/w:p[1]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:p[1]/w:r[position() &gt;= 6]/w:rPr|/w:document/w:body/w:customXml/w:p[1]/w:r[5]/w:rPr">
    <w:rPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:lang|w:szCs|w:sz" />
    </w:rPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:p[3]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[6]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[position() &gt;= 3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[position() &gt;= 2]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[5]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[3]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r[position() &gt;= 3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:p[5]/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:p[8]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r[position() &gt;= 3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:p[7]/w:r/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:p[7]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:p[2]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r[position() &gt;= 3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[2]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[1]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r[position() &gt;= 3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:p[5]/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:p[5]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:p[6]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[4]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 5]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:p[4]/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[position() &gt;= 4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[position() &gt;= 3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:p[position() &gt;= 7]/w:pPr/w:rPr">
    <w:rPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:lang" />
    </w:rPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[3]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[4]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:rPr|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:pPr/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:rPr">
    <w:rPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:lang|w:b" />
    </w:rPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:customXml/w:tr/w:tc/w:p[1]/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r/w:rPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[1]/w:rPr">
    <w:rPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:noProof|w:lang" />
    </w:rPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr|/w:document/w:body/w:customXml/w:tbl/w:tblPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr">
    <w:tblPr>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <xsl:apply-templates select="w:tblW|w:tblLook|w:tblStyle|w:tblBorders" />
    </w:tblPr>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:tbl/w:tblPr/w:tblW|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tblPr/w:tblW|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tblPr/w:tblW|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tblPr/w:tblW|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tblPr/w:tblW|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tblPr/w:tblW|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tblPr/w:tblW">
    <w:tblW>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>
      <w:r xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml">
        <w:t>
          <xsl:value-of select="." />
        </w:t>
      </w:r>
    </w:tblW>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[4]/w:t|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:p[1]/w:r[3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[3]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:p[7]/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r[position() &gt;= 3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:p[1]/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:t|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 5]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:t|/w:document/w:body/w:customXml/w:p[1]/w:r[5]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r[position() &gt;= 3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:p[5]/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r[position() &gt;= 3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:customXml/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[1]/w:t">
    <w:t>
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each>TreeDim<w:p xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml"><w:r><w:t><xsl:value-of select="." /></w:t></w:r></w:p></w:t>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:p[1]/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[position() &gt;= 3]/w:customXml/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:p[1]/w:r[4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:p[1]/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[1]/w:p/w:r[2]/w:t">
    <w:t xml:space="preserve">
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each> <w:p xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml"><w:r><w:t><xsl:value-of select="." /></w:t></w:r></w:p></w:t>
  </xsl:template>
  <xsl:template match="/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[2]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:customXml/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[3]/w:t|/w:document/w:body/w:customXml/w:p[1]/w:r[position() &gt;= 6]/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[9]/w:tc[1]/w:p/w:r[position() &gt;= 3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[6]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[position() &gt;= 2]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[1]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[8]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[position() &gt;= 8]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[position() &gt;= 7]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[4]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[position() &gt;= 6]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:tbl/w:tr[1]/w:tc[position() &gt;= 2]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:p[position() &gt;= 9]/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:p[5]/w:r[1]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:p/w:r[2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r[1]/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[5]/w:tc[position() &gt;= 3]/w:p/w:r[position() &gt;= 4]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[7]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[5]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[position() &gt;= 5]/w:tbl/w:tr[position() &gt;= 5]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:tbl/w:tr[position() &gt;= 3]/w:tc[position() &gt;= 4]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[7]/w:tc[1]/w:p/w:r[position() &gt;= 5]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[4]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[position() &gt;= 10]/w:tc[1]/w:p/w:r[position() &gt;= 3]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[6]/w:tc[2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[4]/w:tbl/w:tr[3]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[2]/w:tbl/w:tr[2]/w:tc[position() &gt;= 2]/w:p/w:r/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[1]/w:tbl/w:tr[3]/w:tc[1]/w:p/w:r[position() &gt;= 2]/w:t|/w:document/w:body/w:customXml/w:customXml/w:customXml[3]/w:tbl/w:tr[3]/w:tc[2]/w:p/w:r/w:t">
    <w:t xml:space="preserve">
      <xsl:for-each select="@w:*|@*[namespace-uri()='']">
        <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
          <xsl:value-of select="." />
        </xsl:attribute>
      </xsl:for-each> report<w:p xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml"><w:r><w:t><xsl:value-of select="." /></w:t></w:r></w:p></w:t>
  </xsl:template>
</xsl:stylesheet>