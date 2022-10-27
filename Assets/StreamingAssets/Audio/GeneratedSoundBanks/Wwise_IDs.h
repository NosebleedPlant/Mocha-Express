/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID MAPLOADED = 3246529682U;
        static const AkUniqueID MUSICMUTE = 153626945U;
        static const AkUniqueID MUSICUNMUTE = 2098179344U;
        static const AkUniqueID PLAYCOOKING = 1262020357U;
        static const AkUniqueID PLAYFOODREADY = 3266981704U;
        static const AkUniqueID PLAYITEMPICKUP = 4016420606U;
        static const AkUniqueID PLAYITEMPLACE = 3776118347U;
        static const AkUniqueID PLAYMENUCLICK = 3838137654U;
        static const AkUniqueID PLAYMENUSELECT = 1024214430U;
        static const AkUniqueID PLAYMEOWDEEP = 921832693U;
        static const AkUniqueID PLAYMEOWNORMAL = 3249829222U;
        static const AkUniqueID PLAYPURR = 2928832990U;
        static const AkUniqueID PLAYSHOOT = 1489638472U;
        static const AkUniqueID SFXMUTE = 1264305561U;
        static const AkUniqueID SFXUNMUTE = 4069662840U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace PLAYERLIFE
        {
            static const AkUniqueID GROUP = 444815956U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID UNALIVE = 1999921723U;
            } // namespace STATE
        } // namespace PLAYERLIFE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace COOKING
        {
            static const AkUniqueID GROUP = 2449017287U;

            namespace SWITCH
            {
                static const AkUniqueID BOIL = 1660835247U;
                static const AkUniqueID FRY = 898583890U;
                static const AkUniqueID MIX = 1182670517U;
            } // namespace SWITCH
        } // namespace COOKING

        namespace PLATEAMMO
        {
            static const AkUniqueID GROUP = 1081040201U;

            namespace SWITCH
            {
                static const AkUniqueID CANNED = 2292682242U;
                static const AkUniqueID PLANETX = 2962930641U;
                static const AkUniqueID VENUSIAN = 2469960200U;
            } // namespace SWITCH
        } // namespace PLATEAMMO

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PLAYERHEALTH = 151362964U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
