using System;
using System.Runtime.InteropServices;
using Htc.Vita.Core.Util;

namespace Htc.Vita.Shell.Interop
{
    internal static partial class Windows
    {
        internal const int /* MAX_PATH */ MaxPath = 260;

        internal enum Error
        {
            /* ERROR_SUCCESS                    (0,   0x0) */ Success               =   0x0,
            /* ERROR_FILE_NOT_FOUND             (2,   0x2) */ FileNotFound          =   0x2,
            /* ERROR_ACCESS_DENIED              (5,   0x5) */ AccessDenied          =   0x5,
            /* ERROR_INVALID_HANDLE             (6,   0x6) */ InvalidHandle         =   0x6,
            /* ERROR_INVALID_DATA              (13,   0xd) */ InvalidData           =   0xd,
            /* ERROR_OUTOFMEMORY               (14,   0xe) */ OutOfMemory           =   0xe,
            /* ERROR_BAD_LENGTH                (24,  0x18) */ BadLength             =  0x18,
            /* ERROR_GEN_FAILURE               (31,  0x1f) */ GenFailure            =  0x1f,
            /* ERROR_HANDLE_DISK_FULL          (39,  0x27) */ HandleDiskFull        =  0x27,
            /* ERROR_NOT_SUPPORTED             (50,  0x32) */ NotSupported          =  0x32,
            /* ERROR_INVALID_PARAMETER         (87,  0x57) */ InvalidParameter      =  0x57,
            /* ERROR_DISK_FULL                (112,  0x70) */ DiskFull              =  0x70,
            /* ERROR_INSUFFICIENT_BUFFER      (122,  0x7a) */ InsufficientBuffer    =  0x7a,
            /* ERROR_INVALID_NAME             (123,  0x7b) */ InvalidName           =  0x7b,
            /* ERROR_FILENAME_EXCED_RANGE     (206,  0xce) */ FilenameExceedRange   =  0xce,
            /* ERROR_MORE_DATA                (234,  0xea) */ MoreData              =  0xea,
            /* ERROR_NO_MORE_ITEMS            (259, 0x103) */ NoMoreItems           = 0x103,
            /* ERROR_SERVICE_DOES_NOT_EXIST  (1060, 0x424) */ ServiceDoesNotExist   = 0x424,
            /* ERROR_DEVICE_NOT_CONNECTED    (1167, 0x48f) */ DeviceNotConnected    = 0x48f,
            /* ERROR_NOT_FOUND               (1168, 0x490) */ NotFound              = 0x490,
            /* ERROR_NO_SUCH_LOGON_SESSION   (1312, 0x520) */ NoSuchLogonSession    = 0x520,
            /* ERROR_BAD_IMPERSONATION_LEVEL (1346, 0x542) */ BadImpersonationLevel = 0x542,
            /* ERROR_RESOURCE_LANG_NOT_FOUND (1815, 0x717) */ ResourceLangNotFound  = 0x717
        }

        [ExternalReference("https://docs.microsoft.com/en-us/windows/desktop/FileIO/file-attribute-constants",
                Description = "FILE_ATTRIBUTE_FLAG enumeration")]
        [Flags]
        internal enum FileAttributeFlags : uint
        {
            /* FILE_ATTRIBUTE_READONLY              */ AttributeReadonly           = 0x00000001,
            /* FILE_ATTRIBUTE_HIDDEN                */ AttributeHidden             = 0x00000002,
            /* FILE_ATTRIBUTE_SYSTEM                */ AttributeSystem             = 0x00000004,
            /* FILE_ATTRIBUTE_DIRECTORY             */ AttributeDirectory          = 0x00000010,
            /* FILE_ATTRIBUTE_ARCHIVE               */ AttributeArchive            = 0x00000020,
            /* FILE_ATTRIBUTE_DEVICE                */ AttributeDevice             = 0x00000040,
            /* FILE_ATTRIBUTE_NORMAL                */ AttributeNormal             = 0x00000080,
            /* FILE_ATTRIBUTE_TEMPORARY             */ AttributeTemporary          = 0x00000100,
            /* FILE_ATTRIBUTE_SPARSE_FILE           */ AttributeSparseFile         = 0x00000200,
            /* FILE_ATTRIBUTE_REPARSE_POINT         */ AttributeReparsePoint       = 0x00000400,
            /* FILE_ATTRIBUTE_COMPRESSED            */ AttributeCompressed         = 0x00000800,
            /* FILE_ATTRIBUTE_OFFLINE               */ AttributeOffline            = 0x00001000,
            /* FILE_ATTRIBUTE_NOT_CONTENT_INDEXED   */ AttributeNotContentIndexed  = 0x00002000,
            /* FILE_ATTRIBUTE_ENCRYPTED             */ AttributeEncrypted          = 0x00004000,
            /* FILE_ATTRIBUTE_INTEGRITY_STREAM      */ AttributeIntegrityStream    = 0x00008000,
            /* FILE_ATTRIBUTE_VIRTUAL               */ AttributeVirtual            = 0x00010000,
            /* FILE_ATTRIBUTE_NO_SCRUB_DATA         */ AttributeNoScrubData        = 0x00020000,
            /* FILE_ATTRIBUTE_RECALL_ON_OPEN        */ AttributeRecallOnOpen       = 0x00040000,
            /* FILE_FLAG_FIRST_PIPE_INSTANCE        */ FlagFirstPipeInstance       = 0x00080000,
            /* FILE_FLAG_OPEN_NO_RECALL             */ FlagOpenNoRecall            = 0x00100000,
            /* FILE_FLAG_OPEN_REPARSE_POINT         */ FlagOpenReparsePoint        = 0x00200000,
            /* FILE_ATTRIBUTE_RECALL_ON_DATA_ACCESS */ AttributeRecallOnDataAccess = 0x00400000,
            /* FILE_FLAG_SESSION_AWARE              */ FlagSessionAware            = 0x00800000,
            /* FILE_FLAG_POSIX_SEMANTICS            */ FlagPosixSemantics          = 0x01000000,
            /* FILE_FLAG_BACKUP_SEMANTICS           */ FlagBackupSemantics         = 0x02000000,
            /* FILE_FLAG_DELETE_ON_CLOSE            */ FlagDeleteOnClose           = 0x04000000,
            /* FILE_FLAG_SEQUENTIAL_SCAN            */ FlagSequentialScan          = 0x08000000,
            /* FILE_FLAG_RANDOM_ACCESS              */ FlagRandomAccess            = 0x10000000,
            /* FILE_FLAG_NO_BUFFERING               */ FlagNoBuffering             = 0x20000000,
            /* FILE_FLAG_OVERLAPPED                 */ FlagOverlapped              = 0x40000000,
            /* FILE_FLAG_WRITE_THROUGH              */ FlagWriteThrough            = 0x80000000
        }

        [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/seccrypto/common-hresult-values")]
        internal enum HResult : uint
        {
            /* S_OK                                              */ SOk                        =        0x0,
            /* S_FALSE                                           */ SFalse                     =        0x1,
            /* E_NOTIMPL                                         */ ENotImpl                   = 0x80004001,
            /* E_POINTER                                         */ EPointer                   = 0x80004003,
            /* E_FAIL                                            */ EFail                      = 0x80004005,
            /* E_UNEXPECTED                                      */ EUnexpected                = 0x8000ffff,
            /* E_ACCESSDENIED                                    */ EAccessDenied              = 0x80070000
                                                                                               | Error.AccessDenied,
            /* E_HANDLE                                          */ EHandle                    = 0x80070000
                                                                                               | Error.InvalidHandle,
            /* HRESULT_FROM_WIN32(ERROR_INVALID_DATA)            */ EWin32InvalidData          = 0x80070000
                                                                                               | Error.InvalidData,
            /* E_OUTOFMEMORY                                     */ EOutOfMemory               = 0x80070000
                                                                                               | Error.OutOfMemory,
            /* HRESULT_FROM_WIN32(ERROR_HANDLE_DISK_FULL)        */ EWin32HandleDiskFull       = 0x80070000
                                                                                               | Error.HandleDiskFull,
            /* E_INVALIDARG                                      */ EInvalidArg                = 0x80070000
                                                                                               | Error.InvalidParameter,
            /* HRESULT_FROM_WIN32(ERROR_DISK_FULL)               */ EWin32DiskFull             = 0x80070000
                                                                                               | Error.DiskFull,
            /* HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)     */ EWin32InsufficientBuffer   = 0x80070000
                                                                                               | Error.InsufficientBuffer,
            /* HRESULT_FROM_WIN32(ERROR_NOT_FOUND)               */ EWin32NotFound             = 0x80070000
                                                                                               | Error.NotFound,
            /* HRESULT_FROM_WIN32(ERROR_RESOURCE_LANG_NOT_FOUND) */ EWin32ResourceLangNotFound = 0x80070000
                                                                                               | Error.ResourceLangNotFound
        }

        [ExternalReference("https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/nf-shlobj_core-shchangenotify",
                Description = "SHCNE enumeration")]
        [Flags]
        internal enum ShellChangeNotifyEventIds : uint
        {
            /* SHCNE_RENAMEITEM       */ RenameItem         = 0x00000001,
            /* SHCNE_CREATE           */ Create             = 0x00000002,
            /* SHCNE_DELETE           */ Delete             = 0x00000004,
            /* SHCNE_MKDIR            */ MakeDirectory      = 0x00000008,
            /* SHCNE_RMDIR            */ RemoveDirectory    = 0x00000010,
            /* SHCNE_MEDIAINSERTED    */ MediaInserted      = 0x00000020,
            /* SHCNE_MEDIAREMOVED     */ MediaRemoved       = 0x00000040,
            /* SHCNE_DRIVEREMOVED     */ DriveRemoved       = 0x00000080,
            /* SHCNE_DRIVEADD         */ DriveAdd           = 0x00000100,
            /* SHCNE_NETSHARE         */ NetShare           = 0x00000200,
            /* SHCNE_NETUNSHARE       */ NetUnshare         = 0x00000400,
            /* SHCNE_ATTRIBUTES       */ Attributes         = 0x00000800,
            /* SHCNE_UPDATEDIR        */ UpdateDirectory    = 0x00001000,
            /* SHCNE_UPDATEITEM       */ UpdateItem         = 0x00002000,
            /* SHCNE_SERVERDISCONNECT */ ServerDisconnect   = 0x00004000,
            /* SHCNE_UPDATEIMAGE      */ UpdateImage        = 0x00008000,
            /* SHCNE_DRIVEADDGUI      */ DriveAddGui        = 0x00010000,
            /* SHCNE_RENAMEFOLDER     */ RenameFolder       = 0x00020000,
            /* SHCNE_FREESPACE        */ FreeSpace          = 0x00040000,
            /* SHCNE_EXTENDED_EVENT   */ ExtendedEvent      = 0x04000000,
            /* SHCNE_ASSOCCHANGED     */ AssociationChanged = 0x08000000,
            /* SHCNE_DISKEVENTS       */ DiskEvents         = 0x0002381f,
            /* SHCNE_GLOBALEVENTS     */ GlobalEvents       = 0x0c0581e0,
            /* SHCNE_ALLEVENTS        */ AllEvents          = 0x7fffffff,
            /* SHCNE_INTERRUPT        */ Interrupt          = 0x80000000
        }

        [ExternalReference("https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/nf-shlobj_core-shchangenotify",
                Description = "SHCNE enumeration")]
        internal enum ShellChangeNotifyFlags : uint
        {
            /* SHCNF_IDLIST      */ IdList      = 0x0000,
            /* SHCNF_PATHA       */ PathA       = 0x0001,
            /* SHCNF_PRINTERA    */ PrinterA    = 0x0002,
            /* SHCNF_DWORD       */ Dword       = 0x0003,
            /* SHCNF_PATHW       */ PathW       = 0x0005,
            /* SHCNF_PRINTERW    */ PrinterW    = 0x0006,
            /* SHCNF_TYPE        */ Type        = 0x00FF,
            /* SHCNF_FLUSH       */ Flush       = 0x1000,
            /* SHCNF_FLUSHNOWAIT */ FlushNoWait = 0x3000
        }

        [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showwindow")]
        internal enum ShowWindowCommand
        {
            /* SW_HIDE            */ Hide            =  0,
            /* SW_SHOWNORMAL      */ ShowNormal      =  1,
            /* SW_NORMAL          */ Normal          = ShowNormal,
            /* SW_SHOWMINIMIZED   */ ShowMinimized   =  2,
            /* SW_SHOWMAXIMIZED   */ ShowMaximized   =  3,
            /* SW_MAXIMIZE        */ Maximize        = ShowMaximized,
            /* SW_SHOWNOACTIVATE  */ ShowNoActivate  =  4,
            /* SW_SHOW            */ Show            =  5,
            /* SW_MINIMIZE        */ Minimize        =  6,
            /* SW_SHOWMINNOACTIVE */ ShowMinNoActive =  7,
            /* SW_SHOWNA          */ ShowNA          =  8,
            /* SW_RESTORE         */ Restore         =  9,
            /* SW_SHOWDEFAULT     */ ShowDefault     = 10,
            /* SW_FORCEMINIMIZE   */ ForceMinimize   = 11,
            /* SW_MAX             */ Max             = ForceMinimize
        }

        [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-filetime",
                Description = "FILETIME structure")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct FileTime : IEquatable<FileTime>
        {
            internal readonly /* DWORD */ uint dwLowDateTime;
            internal readonly /* DWORD */ uint dwHighDateTime;

            public static bool operator ==(FileTime left, FileTime right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(FileTime left, FileTime right)
            {
                return !Equals(left, right);
            }

            public bool Equals(FileTime other)
            {
                return dwLowDateTime == other.dwLowDateTime
                        && dwHighDateTime == other.dwHighDateTime;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                return obj is FileTime && Equals((FileTime) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((int) dwLowDateTime * 397) ^ (int) dwHighDateTime;
                }
            }
        }

        [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/wtypes/ns-wtypes-propertykey",
                Description = "PROPERTYKEY structure")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct PropertyKey : IEquatable<PropertyKey>
        {
            internal readonly /* GUID  */ Guid fmtid;
            internal readonly /* DWORD */ uint pid;

            internal PropertyKey(
                    Guid fmtid,
                    uint pid)
            {
                this.fmtid = fmtid;
                this.pid = pid;
            }

            public static bool operator ==(PropertyKey left, PropertyKey right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(PropertyKey left, PropertyKey right)
            {
                return !Equals(left, right);
            }

            public bool Equals(PropertyKey other)
            {
                return fmtid.Equals(other.fmtid)
                        && pid == other.pid;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                return obj is PropertyKey && Equals((PropertyKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (fmtid.GetHashCode() * 397) ^ (int) pid;
                }
            }
        }

        [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/propidlbase/ns-propidlbase-propvariant",
                Description = "PROPVARIANT structure")]
        [StructLayout(LayoutKind.Explicit)]
        internal struct PropVariant : IEquatable<PropVariant>
        {
            [FieldOffset(0)] internal readonly /* VARTYPE */ ushort vt;
            [FieldOffset(8)] internal readonly /* union   */ IntPtr unionMember;

            internal PropVariant(Guid data)
            {
                vt = (ushort) VarEnum.VT_CLSID;
                var dataInBytes = data.ToByteArray();
                unionMember = Marshal.AllocCoTaskMem(dataInBytes.Length);
                Marshal.Copy(dataInBytes, 0, unionMember, dataInBytes.Length);
            }

            internal PropVariant(string data)
            {
                vt = (ushort) VarEnum.VT_LPWSTR;
                unionMember = Marshal.StringToCoTaskMemUni(data);
            }

            public static bool operator ==(PropVariant left, PropVariant right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(PropVariant left, PropVariant right)
            {
                return !Equals(left, right);
            }

            public bool Equals(PropVariant other)
            {
                return vt == other.vt
                        && unionMember.Equals(other.unionMember);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                return obj is PropVariant && Equals((PropVariant) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (vt.GetHashCode() * 397) ^ unionMember.GetHashCode();
                }
            }
        }

        [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-win32_find_dataw",
                Description = "WIN32_FIND_DATAW structure")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32FindDataW : IEquatable<Win32FindDataW>
        {
                                                                      internal readonly /* DWORD           */ FileAttributeFlags dwFileAttributes;
                                                                      internal readonly /* FILETIME        */ FileTime ftCreationTime;
                                                                      internal readonly /* FILETIME        */ FileTime ftLastAccessTime;
                                                                      internal readonly /* FILETIME        */ FileTime ftLastWriteTime;
                                                                      internal readonly /* DWORD           */ uint nFileSizeHigh;
                                                                      internal readonly /* DWORD           */ uint nFileSizeLow;
                                                                      internal readonly /* DWORD           */ uint dwReserved0;
                                                                      internal readonly /* DWORD           */ uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)] internal readonly /* WCHAR[MAX_PATH] */ string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]      internal readonly /* WCHAR[14]       */ string cAlternateFileName;

            public static bool operator ==(Win32FindDataW left, Win32FindDataW right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Win32FindDataW left, Win32FindDataW right)
            {
                return !Equals(left, right);
            }

            public bool Equals(Win32FindDataW other)
            {
                return dwFileAttributes == other.dwFileAttributes
                        && ftCreationTime.Equals(other.ftCreationTime)
                        && ftLastAccessTime.Equals(other.ftLastAccessTime)
                        && ftLastWriteTime.Equals(other.ftLastWriteTime)
                        && nFileSizeHigh == other.nFileSizeHigh
                        && nFileSizeLow == other.nFileSizeLow
                        && cFileName == other.cFileName
                        && cAlternateFileName == other.cAlternateFileName;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                return obj is Win32FindDataW && Equals((Win32FindDataW) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (int) dwFileAttributes;
                    hashCode = (hashCode * 397) ^ ftCreationTime.GetHashCode();
                    hashCode = (hashCode * 397) ^ ftLastAccessTime.GetHashCode();
                    hashCode = (hashCode * 397) ^ ftLastWriteTime.GetHashCode();
                    hashCode = (hashCode * 397) ^ (int) nFileSizeHigh;
                    hashCode = (hashCode * 397) ^ (int) nFileSizeLow;
                    hashCode = (hashCode * 397) ^ (cFileName != null ? cFileName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (cAlternateFileName != null ? cAlternateFileName.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }
    }
}
