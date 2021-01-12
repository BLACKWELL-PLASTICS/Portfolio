#pragma once

//typedef our variables based on number of bits they possess
// Define our native intergal types to some identifiers that signify their bit size
// Make sure that our integers are 32 bit, signed unsigned and not system dependant

#include <stdint.h>

typedef uint8_t u8; typedef int8_t s8;
typedef uint16_t u16; typedef int16_t s16;
typedef uint32_t u32; typedef int32_t s32;
typedef uint64_t u64; typedef int64_t s64;