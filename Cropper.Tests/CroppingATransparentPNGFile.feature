Feature: Cropping A Transparent PNG File

Scenario: Cropping a simple file
  Given I have a PNG file with transparency named "Before1.png"
  When I crop the transparency
  Then the result should be like "After1.png"

Scenario: Cropping a more complicated file
  Given I have a PNG file with transparency named "Before2.png"
  When I crop the transparency
  Then the result should be like "After2.png"

Scenario: Cropping only the top
  Given I have a PNG file with transparency named "OnlyTopBefore.png"
  When I crop the transparency
  Then the result should be like "OnlyTopAfter.png"

Scenario: Cropping only the bottom
  Given I have a PNG file with transparency named "OnlyBottomBefore.png"
  When I crop the transparency
  Then the result should be like "OnlyBottomAfter.png"

Scenario: Nothing To Crop
  Given I have a PNG file with transparency named "NothingBefore.png"
  When I crop the transparency
  Then the result should be like "NothingAfter.png"