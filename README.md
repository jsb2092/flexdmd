# FlexDMD
FlexDMD is a DMD renderer extension for Visual Pinball. 
FlexDMD was created as a drop-in replacement for UltraDMD, since it was not updated anymore. 

For install instructions and detailed informations, look in the [documentation](./docs/FlexDMD.md).

<b>Disclaimer: this software is in a pre-alpha state. Use at your own risk !</b>

## Overall design
The main design decisions are summarized below:
* Compatible API with UltraDMD, to be a drop-in replacement (done, still needs Uninit to be called on table exit).
* Rely on dmddevice.dll for rendering (see [Freezy's DMD extensions](https://github.com/freezy/dmd-extensions)), therefore supporting output to real DMD devices, virtual DMD, network,...
* Allows to render inside VPX embedded DMD renderer, therefore allowing desktop DMD integration, with support for clean exclusive fullscreen mode.
* In process server (as opposed to out of process), to avoid spilling orphan processes everywhere.
* Clear Open Source licensing; FlexDMD's code is licensed under Apache 2. It has as little dependencies as possible and only on libraries or assets with permissive OSS license too.
* Offer a few improvements missing to UltraDMD (variable font width, comma separated scores, animated score background,...).

## Overall Architecture
The following diagram shows the overall architecture of Visual Pinball and where FlexDMD sits.

<br></br>![Overall Architecture](./docs/media/architecture.svg)
