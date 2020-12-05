cmake_minimum_required(VERSION 3.10)

project(Texture2DDecoder)
set(CMAKE_CXX_STANDARD 17)

add_compile_definitions(DLL_EXPORTS)

file(GLOB t2d_SRC
    "*.h"
    "*.cpp"
)

add_library(Texture2DDecoder SHARED ${t2d_SRC})
