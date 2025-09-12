<p align="center">
  <img src="https://github.com/user-attachments/assets/cfdb777e-c900-4052-9543-d589d46c9ea3" height="300" alt="1" />
  <img src="https://github.com/user-attachments/assets/9898b83a-9d1b-4e87-83ad-3b6a657197f7" height="300" alt="2" />
  <img src="https://github.com/user-attachments/assets/43ac7cb6-3215-4f48-aeeb-fe6b59db309d" height="300" alt="3" />
</p>

# SmartCube
An improved version of the iCubeSmart 3D8 software to control 3D*8 monochrome or multicolor LEDs cube

The original application was limited to monochrome cube (blue only) and preview was stuttering on Windows 11.
This enhanced edition extends its capabilities, improves performance, and refactors several internal components for better maintainability.

## Key Improvements

- **Multi-color cube preview**
  - Outer layers displayed in **blue**
  - Inner layers alternate between **red** and **green**
  - Provides a more accurate visualization compared to the original monochrome display

- **DirectX compatibility with Windows 11**
  - Optimized rendering pipeline
  - Improved performance and stability on modern systems

- **File import/export**
  - Added support for `.xml` files in addition to the legacy `.gpro8` format
  - Enables easier integration with external tools and workflows

- **Code refactoring & translation fixes**
  - Class structure updated for clarity and maintainability
  - Corrected naming inconsistencies caused by Chinese ↔ English translation issues

## Tech Notes

- Developed in **C# / .NET Framework (Windows Forms)**
- Uses **DirectX** for 3D rendering
- Tested on **Windows 7** and **Windows 11**

## Disclaimer

This work is based on the decompilation of software originally created by another company. It is provided "as is" without any warranties, express or implied. The original company does not endorse, support, or approve this work in any way. Use of this code is at your own risk, and you assume full responsibility for any consequences that may arise.
