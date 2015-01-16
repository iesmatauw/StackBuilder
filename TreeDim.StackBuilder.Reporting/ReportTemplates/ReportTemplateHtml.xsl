<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:param name="lang"/> <!-- param set in command line -->
  <xsl:variable name="loc" select="document(concat( $lang, '.xml'), .)/strings"/>
  <xsl:output method="html"></xsl:output>
  <xsl:template match="report">
    <html>
      <head>
        <title>
          <xsl:value-of select="name"></xsl:value-of> <xsl:value-of select="$loc/str[@name='report']"/>
        </title>
        <style type="text/css">
          .style1
          {
          color:blue;
          }
          .style2
          {
          width: 50mm;
          color:black;
          font-family:Arial;
          font-size:10px;
          }
          .style3
          {
          color:black;
          font-family:Arial;
          font-size:10px;
          }
          body
          {
          font-family:Arial;
          font-size:11px;
          margin: 5%;
          width: 90%;
          padding: 0;
          }
          h1
          {
          color:black;
          font-size:20px;
          font-family:Arial;
          width:200mm
          }
          h2
          {
          color:red;
          font-size:16px;
          font-family:Arial;
          }
          h3
          {
          color:blue;
          font-size:12px;
          font-family:Arial;
          }
          table
          {
          border:solid grey 1px;
          width:200mm;
          border-spacing: 0px;
          cell-spacing: 0px;
          }
          td
          {
          padding: 0px;
          }
        </style>
      </head>
      <body>
        <table class="style1" cellpadding="4">
          <tr>
            <td class="style2" colspan="1">
              <b>
                <xsl:value-of select="$loc/str[@name='Document']"/>
              </b>
            </td>
            <td class="style3" colspan="2">
              <xsl:value-of select="name"/>
            </td>
            <xsl:if test="companyLogo">
              <td colspan="1" align="middle">
                <xsl:apply-templates select="companyLogo"/>
              </td>
            </xsl:if>            
          </tr>
          <tr>
            <td class="style2" colspan="1">
              <b>
                <xsl:value-of select="$loc/str[@name='Description']"/>
              </b>
            </td>
            <td class="style3" colspan="2">
              <xsl:value-of select="description"/>
            </td>
            <td class="style2" colspan="1"/>
          </tr>
          <tr>
            <td class="style2" colspan="1">
              <b>
                <xsl:value-of select="$loc/str[@name='Date']"/>
              </b>
            </td>
            <td class="style3" colspan="1">
              <xsl:value-of select="dateOfCreation"/>
            </td>
            <td class="style2" colspan="1">
              <b>
                <xsl:value-of select="$loc/str[@name='Author']"/>
              </b>
            </td>
            <td class="style3" colspan="1">
              <xsl:value-of select="author"></xsl:value-of>
            </td>
          </tr>
        </table>
        <xsl:apply-templates select="boxCaseAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="boxCasePalletAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="casePalletAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="cylinderPalletAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="hCylinderPalletAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="truckAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="ectAnalysis"></xsl:apply-templates>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="boxCaseAnalysis">
    <h2>
      <xsl:value-of select="$loc/str[@name='Box/Case analysis']"/>
    </h2>
    <xsl:apply-templates select="box"></xsl:apply-templates>
    <xsl:apply-templates select="caseWithInnerDims"></xsl:apply-templates>
    <xsl:apply-templates select="caseConstraintSet"></xsl:apply-templates>
    <xsl:apply-templates select="boxCaseSolution"></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="boxCasePalletAnalysis">
    <h2>
      <xsl:value-of select="$loc/str[@name='Box/Case/Pallet analysis']"/>
    </h2>
    <xsl:apply-templates select="box"></xsl:apply-templates>
    <xsl:apply-templates select="caseWithInnerDims"></xsl:apply-templates>
    <xsl:apply-templates select="boxCasePalletSolution"></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="casePalletAnalysis">
    <h2>
      <xsl:value-of select="$loc/str[@name='Pallet analysis']"/>
    </h2>
    <xsl:apply-templates select="case"></xsl:apply-templates>
    <xsl:apply-templates select="bundle"></xsl:apply-templates>
    <xsl:apply-templates select="box"></xsl:apply-templates>
    <xsl:apply-templates select="caseOfBoxes"></xsl:apply-templates>
    <xsl:apply-templates select="interlayer"></xsl:apply-templates>
    <xsl:apply-templates select="pallet"></xsl:apply-templates>
    <xsl:apply-templates select="constraintSet"></xsl:apply-templates>
    <xsl:apply-templates select="caseOptimConstraintSet"></xsl:apply-templates>
    <xsl:apply-templates select="palletSolution"></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="cylinderAnalysis">
    <h2>
      <xsl:value-of select="$loc/str[@name='Cylinder analysis']"/>
    </h2>
    <xsl:apply-templates select="cylinder"></xsl:apply-templates>
    <xsl:apply-templates select="pallet"></xsl:apply-templates>
    <xsl:apply-templates select="interlayer"></xsl:apply-templates>
    <xsl:apply-templates select="cylinderPalletConstraintSet"></xsl:apply-templates>
    <xsl:apply-templates select="cylinderPalletSolution"></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="truckAnalysis">
    <h2>
      <xsl:value-of select="$loc/str[@name='Truck analysis']"/>
    </h2>
    <xsl:apply-templates select="truck"></xsl:apply-templates>
    <xsl:apply-templates select="truckSolution"></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="ectAnalysis">
    <h2>
      <xsl:value-of select="$loc/str[@name='Box Compression Test analysis']"/>
    </h2>
    <xsl:apply-templates select="cardboard"></xsl:apply-templates>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Case type']"/>
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Printed surface']"/>
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Mc Kee Formula']"/>
          </b>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <xsl:value-of select="caseType"></xsl:value-of>
        </td>
        <td class="style3">
          <xsl:value-of select="printedSurface"></xsl:value-of>
        </td>
        <td class="style3">
          <xsl:value-of select="mcKeeFormulaMode"></xsl:value-of>
        </td>
      </tr>
    </table>
    <xsl:apply-templates select="bct_static"></xsl:apply-templates>
    <xsl:apply-templates select="bct_dynamic"></xsl:apply-templates>
  </xsl:template>
  <!-- #### CASE ####-->
  <xsl:template match="case">
    <h3>Case</h3>
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Length']"/> (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="5" align="middle">
          <xsl:apply-templates select="view_case_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Width']"/> (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Height']"/> (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
      </tr>
      <xsl:if test="admissibleLoad">
        <tr>
          <td class="style2">
            <b>
              <xsl:value-of select="$loc/str[@name='Admissible load on top']"/> (<xsl:value-of select="admissibleLoad/unit"></xsl:value-of>)
            </b>
          </td>
          <td class="style3" colspan="1">
            <xsl:value-of select="admissibleLoad/value"></xsl:value-of>
          </td>
        </tr>
      </xsl:if>
    </table>
  </xsl:template>
  <!--#### CYLINDER ####-->
  <xsl:template match="cylinder">
    <h3>
      <xsl:value-of select="$loc/str[@name='Cylinder']"/>
    </h3>
    <table class="style1" cellpadding="4">
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Radius']"/> (<xsl:value-of select="radius/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="radius/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Height']"/> (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_cylinder_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CASE WITH INNER DIMS #### -->
  <xsl:template match="caseWithInnerDims">
    <h3>
      <xsl:value-of select="$loc/str[@name='Case']"/>
    </h3>
    <table class="style1" cellpadding="4">
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Ext. length']"/> (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Interior length']"/> (<xsl:value-of select="innerLength/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="innerLength/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Ext. width']"/> (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Interior width']"/> (<xsl:value-of select="innerWidth/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="innerWidth/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Ext. height']"/> (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Interior height']"/> (<xsl:value-of select="innerHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="innerHeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_case_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!-- #### PALLET ####-->
  <xsl:template match="pallet">
    <h3>
      <xsl:value-of select="$loc/str[@name='Pallet']"/>
    </h3>
    <table class="style1" cellpadding="4">
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Length']"/> (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="5" colspan="2" align="middle">
          <xsl:apply-templates select="view_pallet_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Width']"/> (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Height']"/> (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
      </tr>
      <xsl:if test="admissibleLoad">
        <tr>
          <td class="style2" colspan="1">
            <b>
              <xsl:value-of select="$loc/str[@name='Admissible load weight']"/> (<xsl:value-of select="admissibleLoad/unit"></xsl:value-of>)
            </b>
          </td>
          <td class="style3" colspan="1">
            <xsl:value-of select="admissibleLoad/value"></xsl:value-of>
          </td>
        </tr>
      </xsl:if>
    </table>
  </xsl:template>
  <!--BOX-->
  <xsl:template match="box">
    <h3>Box</h3>
    <table class="style1">
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Length']"/> (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="4" align="middle">
          <xsl:apply-templates select="view_box_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Width']"/> (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Height']"/> (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### INTERLAYER ####-->
  <xsl:template match="interlayer">
    <h3>
      <xsl:value-of select="$loc/str[@name='Interlayer']"/>
    </h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Length']"/> (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="4" align="middle">
          <xsl:apply-templates select="view_interlayer_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Width']"/> (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Thickness']"/> (<xsl:value-of select="thickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="thickness/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### PALLET CORNER ####-->
  <!--#### PALLET CAP ####-->
  <!--#### PALLET FILM ####-->
  <!--#### BUNDLE ####-->
  <xsl:template match="bundle">
    <h3>
      <xsl:value-of select="$loc/str[@name='Bundle']"/>
    </h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <strong>
            <xsl:value-of select="$loc/str[@name='Length']"/> (<xsl:value-of select="length/unit"></xsl:value-of>)
          </strong>
        </td>
        <td class="style3">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="6" align="middle">
          <xsl:apply-templates select="view_bundle_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Width']"/> (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Number of flats']"/>
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="numberOfFlats"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Unit thickness']"/> (<xsl:value-of select="unitThickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="unitThickness/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Unit weight']"/> (<xsl:value-of select="unitWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="unitWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>
            <xsl:value-of select="$loc/str[@name='Total thickness']"/> (<xsl:value-of select="totalThickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="totalThickness/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>
            <xsl:value-of select="$loc/str[@name='Total weight']"/> (<xsl:value-of select="totalWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="totalWeight/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!-- #### CASE OF BOXES #### -->
  <xsl:template match="caseOfBoxes">
    <h3>
      <xsl:value-of select="$loc/str[@name='Case of boxes']"/>
    </h3>
    <table class="style1" cellpadding="4">
      <tr>
        <td class="style2" colspan="1" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style3" colspan="3" width="75%">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td class="style3" colspan="3" width="75%">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Length']"/> (<xsl:value-of select="outerlength/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerlength/value"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Inner length']"/> (<xsl:value-of select="innerlength/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="innerLength/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Width']"/> (<xsl:value-of select="outerWidth/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerWidth/value"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Inner width']"/> (<xsl:value-of select="outerWidth/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="innerWidth/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Height']"/> (<xsl:value-of select="outerHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerHeight/value"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Inner height']"/> (<xsl:value-of select="innerHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="innerHeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Volume']"/> (<xsl:value-of select="outerVolume/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerVolume/value"></xsl:value-of>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Inner volume']"/> (<xsl:value-of select="innerVolume/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="innerVolume/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Empty weight']"/> (<xsl:value-of select="emptyWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="emptyWeight/value"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Number of boxes']"/>
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="numberOfBoxes"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Layout']"/>
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="noX"></xsl:value-of>*<xsl:value-of select="noY"></xsl:value-of>*<xsl:value-of select="noZ"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Dim0']"/>
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="dim0"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            <xsl:value-of select="$loc/str[@name='Dim1']"/>
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="dim1"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_caseOfBoxes_iso1"></xsl:apply-templates>
        </td>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_caseOfBoxes_iso2"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CONSTRAINT SET ####-->
  <xsl:template match="constraintSet">
    <h3>
      <xsl:value-of select="$loc/str[@name='Constraint set']"/>
    </h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Overhang Length / Width']"/> (<xsl:value-of select="overhangX/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangX/value"></xsl:value-of> / <xsl:value-of select="overhangY/value"></xsl:value-of>
        </td>
      </tr>
      <xsl:if test="maximumPalletWeightGroup">
        <xsl:apply-templates select="maximumPalletWeightGroup">
        </xsl:apply-templates>
      </xsl:if>
      <xsl:apply-templates select="maximumPalletHeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumNumberOfItemsGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="admissibleLoadOnTopGroup">
      </xsl:apply-templates>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Allowed ortho axes']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowedOrthoAxis"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Allow aligned layers']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowAlignedLayers"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Allow alternate layers']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowAlternateLayers"></xsl:value-of>
        </td>
      </tr>
      <xsl:apply-templates select="interlayerPeriodGroup">
      </xsl:apply-templates>
    </table>
  </xsl:template>
  <!-- #### CYLINDER PALLET CONSTRAINT SET #### -->
  <xsl:template match="cylinderPalletConstraintSet">
    <h3>
      <xsl:value-of select="$loc/str[@name='Constraint set']"/>
    </h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2" width="20%">
          <b>
            <xsl:value-of select="$loc/str[@name='Overhang Length / Width']"/> (<xsl:value-of select="overhangX/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangX/value"></xsl:value-of> / <xsl:value-of select="overhangY/value"></xsl:value-of>
        </td>
      </tr>
      <xsl:apply-templates select="maximumPalletWeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumPalletHeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumNumberOfItemsGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="admissibleLoadOnTopGroup">
      </xsl:apply-templates>
    </table>
  </xsl:template>
  <!-- #### HCYLINDER PALLET CONSTRAINT SET #### -->
  <xsl:template match="hCylinderPalletConstraintSet">
    <h3>
      <xsl:value-of select="$loc/str[@name='Constraint set']"/>
    </h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2" width="20%">
          <b>
            <xsl:value-of select="$loc/str[@name='Overhang Length / Width']"/> (<xsl:value-of select="overhangX/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangX/value"></xsl:value-of> / <xsl:value-of select="overhangY/value"></xsl:value-of>
        </td>
      </tr>
      <xsl:apply-templates select="maximumPalletWeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumPalletHeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumNumberOfItemsGroup">
      </xsl:apply-templates>
    </table>
  </xsl:template>
  <!--#### CASE OPTIM CONSTRAINT SET ####-->
  <xsl:template match="caseOptimConstraintSet">
    <h3>
      <xsl:value-of select="$loc/str[@name='Case optimization constraint set']"/>
    </h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Wall thickness']"/> (<xsl:value-of select="wallThickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="wallThickness/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Case limit (min)']"/>
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseLimitMin"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>
            <xsl:value-of select="$loc/str[@name='Case limit (max)']"/>
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseLimitMax"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CASE CONSTRAINTSET ####-->
  <xsl:template match="caseConstraintSet">
    <h3>
      <xsl:value-of select="$loc/str[@name='Case filling constraint']"/>
    </h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Allowed orthogonal axis']"/>
          </b>
        </td>
        <td class="style3">
          <xsl:apply-templates select="allowedOrthoAxis"></xsl:apply-templates>
        </td>
      </tr>
      <xsl:apply-templates select="maximumCaseWeightGroup"></xsl:apply-templates>
      <xsl:apply-templates select="minimumBoxPerCaseGroup"></xsl:apply-templates>
      <xsl:apply-templates select="maximumBoxPerCaseGroup"></xsl:apply-templates>
    </table>
  </xsl:template>
  <xsl:template match="maximumCaseWeightGroup">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="$loc/str[@name='Maximum case weight']"/> (<xsl:value-of select="maximumCaseWeight/unit"></xsl:value-of>)
        </b>
      </td>
      <td class="style3">
        <xsl:value-of select="maximumCaseWeight/value"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="minimumBoxPerCaseGroup">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="$loc/str[@name='Minimum number of items']"/>
        </b>
      </td>
      <td class="style3">
        <xsl:value-of select="minimumBoxPerCase"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="maximumBoxPerCaseGroup">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="$loc/str[@name='Maximum number of items']"/>
        </b>
      </td>
      <td class="style3">
        <xsl:value-of select="maximumBoxPerCase"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <!--#### PALLET SOLUTION ####-->
  <xsl:template match="palletSolution">
    <h3>
      <xsl:value-of select="$loc/str[@name='Selected solution']"/>
    </h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Title']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="title"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Number of cases']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="caseCount"></xsl:value-of>
        </td>
      </tr>
      <xsl:if test="interlayerCount">
        <tr>
          <td class="style2">
            <b>
              <xsl:value-of select="$loc/str[@name='Number of interlayers']"/>
            </b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="interlayerCount"></xsl:value-of>
          </td>
        </tr>
      </xsl:if>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Pallet weight']"/> (<xsl:value-of select="palletWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Pallet height']"/> (<xsl:value-of select="palletHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletHeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Efficiency']"/> (%)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="efficiency"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_front"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_left"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_right"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_back"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_palletsolution_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
    <h3>
      <xsl:value-of select="$loc/str[@name='Layer(s)']"/>
    </h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Index']"/>
          </b>
        </td>
        <td class="style3">
          <b>
            <xsl:value-of select="$loc/str[@name='Number of cases']"/>
          </b>
        </td>
        <td class="style3" align="middle">
          <b>
            <xsl:value-of select="$loc/str[@name='Image']"/>
          </b>
        </td>
      </tr>
      <xsl:apply-templates select="layer"></xsl:apply-templates>
    </table>
  </xsl:template>
  <!-- #### CYLINDER PALLET SOLUTION #### -->
  <xsl:template match="cylinderPaletSolution">
    <h3>
      <xsl:value-of select="$loc/str[@name='Selected solution']"/>
    </h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Title']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="title"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Number of cylinders']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="cylinderCount"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Pallet weight']"/> (<xsl:value-of select="palletWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Pallet height']"/> (<xsl:value-of select="palletHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletHeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Efficiency']"/> (%)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="efficiency"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_front"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_left"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_right"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_back"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_palletsolution_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
    <h3>
      <xsl:value-of select="$loc/str[@name='Layer(s)']"/>
    </h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Index']"/>
          </b>
        </td>
        <td class="style3">
          <b>
            <xsl:value-of select="$loc/str[@name='Number of case(s)']"/>
          </b>
        </td>
        <td class="style3" align="middle">
          <b>
            <xsl:value-of select="$loc/str[@name='Image']"/>
          </b>
        </td>
      </tr>
      <xsl:apply-templates select="layer"></xsl:apply-templates>
    </table>
  </xsl:template>
  <!--#### BOX/CASE SOLUTION-->
  <xsl:template match="boxCaseSolution">
   <h3>
     <xsl:value-of select="$loc/str[@name='Case filling']"/>
   </h3>
    <table class="style1" cellpadding="4">
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Title']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="title"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Boxes / layer']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="boxPerLayerCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Layers / case']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="boxLayersCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Boxes / Case']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="boxPerCaseCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Load weight']"/> (<xsl:value-of select="LoadWeight/unit"/>)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="LoadWeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Case weight']"/> (<xsl:value-of select="CaseWeight/unit"/>)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="CaseWeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Efficiency weight']"/> (%)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="EfficiencyWeight"/> 
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Efficiency volume']"/> (%)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="EfficiencyVolume"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            <xsl:value-of select="$loc/str[@name='Limit reached']"/>
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="LimitReached"/>
        </td>
      </tr>
      <tr>
        <td align="middle">
          <xsl:apply-templates select="view_caseSolution_front"/>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_caseSolution_left"/>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_caseSolution_right"/>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_caseSolution_back"/>
        </td>
      </tr>
      <tr>
        <td align="middle" colspan="4">
          <xsl:apply-templates select="view_caseSolution_iso"/>
        </td>
      </tr>
    </table>
  </xsl:template>  
  <!--#### BOX/CASE/PALLET SOLUTION ####-->
  <xsl:template match="boxCasePalletSolution">
    <h3>
      <xsl:value-of select="$loc/str[@name='Case filling']"/>
    </h3>
    <table class="style1" cellpadding="5">
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>
            <xsl:value-of select="$loc/str[@name='Title']"/>
          </b>
        </td>
        <td class="style3" colspan="4" width="60%">
          <xsl:value-of select="title"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>
            <xsl:value-of select="$loc/str[@name='Layer homogeneous']"/>
          </b>
        </td>
        <td class="style3" colspan="4" width="60%">
          <xsl:value-of select="homogeneousLayer"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style3" colspan="1" width="40%"></td>
        <td class="style2" colspan="2" width="30%">
          <b>
            <xsl:value-of select="$loc/str[@name='Case']"/>
          </b>
        </td>
        <td class="style2" colspan="2" width="30%">
          <b>
            <xsl:value-of select="$loc/str[@name='Pallet']"/>
          </b>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>
            <xsl:value-of select="$loc/str[@name='Number of boxes']"/>
          </b>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="boxPerCaseCount"></xsl:value-of>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="boxPerPalletCount"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>
            <xsl:value-of select="$loc/str[@name='Efficiency']"/> (%)
          </b>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="caseEfficiency"></xsl:value-of>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="palletEfficiency"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>
            <xsl:value-of select="$loc/str[@name='Weight']"/> (<xsl:value-of select="caseWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="caseWeight/value"></xsl:value-of>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="palletWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td colspan="5" align="middle">
          <xsl:apply-templates select="view_caseSolution_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--COMPANYLOGO-->
  <xsl:template match="companyLogo">
    <img src="images\companyLogo.png" width="150" height="50" align="middle"/>
  </xsl:template>
  <!--CASE-->
  <xsl:template match="view_case_iso">
    <img src="images\view_case_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--CYLINDER-->
  <xsl:template match="view_cylinder_iso">
    <img src="images\view_cylinder_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--BOX-->
  <xsl:template match="view_box_iso">
    <img src="images\view_box_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--PALLET-->
  <xsl:template match="view_pallet_iso">
    <img src="images\view_pallet_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--INTERLAYER-->
  <xsl:template match="view_interlayer_iso">
    <img src="images\view_interlayer_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--BUNDLE-->
  <xsl:template match="view_bundle_iso">
    <img src="images\view_bundle_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--PALLET SOLUTION-->
  <xsl:template match="view_palletsolution_front">
    <img src="images\view_palletsolution_front.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_palletsolution_left">
    <img src="images\view_palletsolution_left.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_palletsolution_right">
    <img src="images\view_palletsolution_right.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_palletsolution_back">
    <img src="images\view_palletsolution_back.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_palletsolution_iso">
    <img src="images\view_palletsolution_iso.png" width="450" height="450" align="middle"></img>
  </xsl:template>
  <!--CASE OF BOXES-->
  <xsl:template match="view_caseOfBoxes_iso1">
    <img src="images\view_caseOfBoxes_iso1.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_caseOfBoxes_iso2">
    <img src="images\view_caseOfBoxes_iso2.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_caseSolution_front">
    <img src="images\view_caseSolution_front.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_caseSolution_back">
    <img src="images\view_caseSolution_back.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_caseSolution_left">
    <img src="images\view_caseSolution_left.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_caseSolution_right">
    <img src="images\view_caseSolution_right.png" width="150" height="150" align="middle"></img>
  </xsl:template>  
  <xsl:template match="view_caseSolution_iso">
    <img src="images\view_caseSolution_iso.png" width="300" height="300" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_truck_iso">
    <img src="images\view_truck_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_trucksolution_top">
    <img src="images\view_trucksolution_top.png" width="450" height="450" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_trucksolution_iso">
    <img src="images\view_trucksolution_iso.png" width="450" height="450" align="middle"></img>
  </xsl:template>
  <!--STOP STACKING CONDITIONS-->
  <xsl:template match="maximumPalletWeightGroup">
    <xsl:if test="maximumPalletWeight">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Maximum pallet weight']"/> (<xsl:value-of select="maximumPalletWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="maximumPalletWeight/value"></xsl:value-of>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>
  <xsl:template match="maximumPalletHeightGroup">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="$loc/str[@name='Maximum pallet height']"/> (<xsl:value-of select="maximumPalletHeight/unit"></xsl:value-of>)
        </b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="maximumPalletHeight/value"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="maximumNumberOfItemsGroup">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="$loc/str[@name='Maximum number of items']"/>"</b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="maximumNumberOfItems"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="admissibleLoadOnTopGroup">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="$loc/str[@name='Maximum load on top']"/> (<xsl:value-of select="admissibleLoadOnTop/unit"></xsl:value-of>)
        </b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="admissibleLoadOnTop/value"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <!--INTERLAYER PERIOD-->
  <xsl:template match="interlayerPeriodGroup">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="$loc/str[@name='Interlayer period']"/>
        </b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="interlayerPeriod"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <!--LAYER-->
  <xsl:template match="layer">
    <tr>
      <td class="style2">
        <xsl:value-of select="layerId"></xsl:value-of>
      </td>
      <td class="style3">
        <xsl:value-of select="layerCaseCount"></xsl:value-of>
      </td>
      <td align="middle">
        <xsl:if test="layerId='1'">
          <img src="images\layerImage1.png" width="150" height="150"/>
        </xsl:if>
        <xsl:if test="layerId='2'">
          <img src="images\layerImage2.png" width="150" height="150"/>
        </xsl:if>
      </td>
    </tr>
  </xsl:template>
  <!--TRUCK-->
  <xsl:template match="truck">
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Description']"/>
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Length']"/> (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="4" align="middle">
          <xsl:apply-templates select="view_truck_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Width']"/> (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Height']"/> (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Admissible load']"/> (<xsl:value-of select="admissibleLoad/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="admissibleLoad/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--TRUCK SOLUTION-->
  <xsl:template match="truckSolution">
    <h3>
      <xsl:value-of select="$loc/str[@name='Selected solution']"/>
    </h3>
    <table class="style1" cellpadding="4">
      <xsl:if test="title">
        <tr>
          <td class="style2">
            <b>
              <xsl:value-of select="$loc/str[@name='Title']"/>
            </b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="title"></xsl:value-of>
          </td>
        </tr>
      </xsl:if>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Pallet count']"/>
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="palletCount"></xsl:value-of>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Case count']"/>
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseCount"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Load weight']"/> (<xsl:value-of select="loadWeight/unit"></xsl:value-of>):
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="loadWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Load efficiency']"/> (%)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="loadEfficiency"></xsl:value-of>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Volume efficiency']"/> (%)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="volumeEfficiency"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_trucksolution_top"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_trucksolution_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--CARDBOARD-->
  <xsl:template match="cardboard">
    <h3>
      <xsl:value-of select="$loc/str[@name='Carton']"/>
    </h3>
    <b>
      <xsl:value-of select="$loc/str[@name='Cardboard']"/>
    </b>
    <table border="1" cellpadding="5">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Name']"/>
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Thickness']"/> (<xsl:value-of select="thickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='ECT']"/> (<xsl:value-of select="ect/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='StiffnessX']"/> (<xsl:value-of select="stiffnessX/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='StiffnessY']"/> (<xsl:value-of select="stiffnessY/unit"></xsl:value-of>)
          </b>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="thickness/value"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="ect/value"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="stiffnessX/value"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="stiffnessY/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_STATIC-->
  <xsl:template match="bct_static">
    <table border="1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Static BCP']"/>
          </b>
        </td>
        <td class="style3">
          <xsl:text></xsl:text>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_DYNAMIC-->
  <xsl:template match="bct_dynamic">
    <b>
      <xsl:value-of select="$loc/str[@name='Dynamic BCP']"/>
    </b>
    <table border="1" cellpadding="7">
      <tr>
        <td class="style2">
          <b>
            <xsl:value-of select="$loc/str[@name='Storage']"/>
          </b>
        </td>
        <td class="style2">
          <b>0-45 %</b>
        </td>
        <td class="style2">
          <b>46-55 %</b>
        </td>
        <td class="style2">
          <b>56-65 %</b>
        </td>
        <td class="style2">
          <b>66-75 %</b>
        </td>
        <td class="style2">
          <b>76-85 %</b>
        </td>
        <td class="style2">
          <b>86-100 %</b>
        </td>
      </tr>
      <xsl:apply-templates select="bct_dynamic_storage"></xsl:apply-templates>
    </table>
  </xsl:template>
  <!--BCT_DYNAMIC_STORAGE-->
  <xsl:template match="bct_dynamic_storage">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="duration"></xsl:value-of>
        </b>
      </td>
      <xsl:apply-templates select="humidity_0_45"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_46_55"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_56_65"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_66_75"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_76_85"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_86_100"></xsl:apply-templates>
    </tr>
  </xsl:template>
  <!--humidity_0_45-->
  <xsl:template match="humidity_0_45">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_46_55-->
  <xsl:template match="humidity_46_55">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_56_65-->
  <xsl:template match="humidity_56_65">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_66_75-->
  <xsl:template match="humidity_66_75">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_76_85-->
  <xsl:template match="humidity_76_85">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_76_85-->
  <xsl:template match="humidity_86_100">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>